using UnityEngine;
using System.Collections;

public class DwarfAni : MonoBehaviour {
    
    private Animator animator;
    private MeleeAttack melee;
    
    private float lastX = 0;
    private float scale;
    private float direction = 1;
    private float distToGround;
    
    public float Direction {
        get { return direction; }
    }
    public bool Swinging {
        get;
        set;
    }
    public bool Punching {
        get;
        set;
    }

    public void Start() {
        animator = GetComponent<Animator>();
        melee = GetComponent<MeleeAttack>();
        scale = transform.localScale.x;
        distToGround = collider.bounds.extents.y;
    }
    
    public void FixedUpdate() {
        // Flip sprite
        Vector3 localScale = transform.localScale;
        if (transform.position.x < lastX) {
            direction = -1;
            localScale.x = -scale;
        } else if (transform.position.x > lastX) {
            direction = 1;
            localScale.x = scale;
        }
        transform.localScale = localScale;

        if (!GetComponent<CharacterMotor>().IsGrounded()) {
            SetJump();
        } else if (lastX - transform.position.x < -0.002 || lastX - transform.position.x > 0.002) {
            SetWalk();
        } else {
            SetIdle();
        }

        // Record last x
        lastX = transform.position.x;
    }
    public bool IsGrounded() {
        return Physics.Raycast(transform.position, -Vector3.up, distToGround + 0.2f);
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

}
