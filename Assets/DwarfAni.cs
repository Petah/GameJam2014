using UnityEngine;
using System.Collections;

public class DwarfAni : MonoBehaviour {
    
    private Animator animator;
    private MeleeAttack melee;
    public   AudioClip fallSound;
    
    
    private Vector3 impact = Vector3.zero;
    private CharacterController character;

    private bool fallFinished = true;

    private float lastX = 0;
    private float scale;
    private float direction = 1;
    private float distToGround;
    private bool falling = false;

    private int kills = 0;

    private bool dead = false;

    public Impact lastHit;
    
    public float Direction {
        get { return direction; }
    }
    
    public bool Dead {
        get { return dead; }
        set { dead = value; }
    }
    
    public bool Swinging {
        get;
        set;
    }
    
    public int Kills {
        get { return kills; }
    }

    public bool Punching {
        get;
        set;
    }

    public void Start() {
        animator = GetComponent<Animator>();
        melee = GetComponent<MeleeAttack>();
        character = GetComponent<CharacterController>();

        scale = transform.localScale.x;
        distToGround = collider.bounds.extents.y;
    }
    
    public void Update() {
        if (dead) {
            transform.position = new Vector3(0, 10000000);
        }
    }
    
    public void FixedUpdate() {
        // Apply the impact force:
        if (impact.magnitude > 0.2f) {
            character.Move(impact * Time.deltaTime);
        }
        // Consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
        
        // Flip sprite
        Vector3 localScale = transform.localScale;

        if ((impact.x > 0.02 || impact.x < -0.02) && !fallFinished) {
            SetFall(true);

            if (impact.x > 0) {
                direction = -1;
                localScale.x = -scale;
            } else {
                direction = 1;
                localScale.x = scale;
            }

            transform.localScale = localScale;
        } else {
            SetFall(false);


            if (transform.position.x < lastX) {
                direction = -1;
                localScale.x = -scale;
            } else if (transform.position.x > lastX) {
                direction = 1;
                localScale.x = scale;
            }
            transform.localScale = localScale;
        }


        if (!GetComponent<CharacterMotor>().IsGrounded()) {
            falling = true;
            SetJump();
        } else if (lastX - transform.position.x < -0.002 || lastX - transform.position.x > 0.002) {
            if (falling) {
                audio.PlayOneShot(fallSound);
                falling = false;
            }
            SetWalk();
        } else {
            if (falling) {
                audio.PlayOneShot(fallSound);
                falling = false;
            }
            SetIdle();
        }


        // Record last x
        lastX = transform.position.x;
    }
    public bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.2f);
    }

    
    public void SetFall(bool fall) {
        foreach (Animator animator in gameObject.GetComponentsInChildren<Animator>()) {
            animator.SetBool("Fall", fall);
        }
    }

    public void SetJump() {
        foreach (Animator animator in gameObject.GetComponentsInChildren<Animator>()) {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", true);
            animator.SetBool("Punch", melee.IsPunching());
            animator.SetBool("Swing", melee.IsSwinging());
        }
    }
    
    public void SetWalk() {
        foreach (Animator animator in gameObject.GetComponentsInChildren<Animator>()) {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);
            animator.SetBool("Jump", false);
            animator.SetBool("Punch", melee.IsPunching());
            animator.SetBool("Swing", melee.IsSwinging());
        }
    }
    
    public void SetIdle() {
        foreach (Animator animator in gameObject.GetComponentsInChildren<Animator>()) {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", false);
            animator.SetBool("Punch", melee.IsPunching());
            animator.SetBool("Swing", melee.IsSwinging());
        }
    }
    
    public void OnDrawGizmos() {
        Gizmos.DrawRay(transform.position + (Vector3.down * 1.2f), Vector3.down * 0.1f);
    }

    public void AddImpact(Impact incoming) {
        Vector3 direction;
        if (incoming.from.transform.position.x > transform.position.x) {
            direction = Vector3.left;
        } else {
            direction = Vector3.right;
        }
        impact += direction * 15f;
        fallFinished = false;

        if (incoming.swing) {
            DwarfAni ani = incoming.from.GetComponent<DwarfAni>();
            ani.kills++;
        }

        lastHit = incoming;
    }

    public void FinishFall() {
        fallFinished = true;
        lastHit = null;
    }

    public void Die() {
        if (lastHit.swing) {
            dead = true;
        }
        lastHit = null;
    }
}
