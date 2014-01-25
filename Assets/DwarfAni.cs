using UnityEngine;
using System.Collections;

public class DwarfAni : MonoBehaviour {
    
    private Animator animator;
    
    private float lastX = 0;
    private float scale;
    private float direction = 1;

    public float Direction {
        get { return direction; }
    }

    public void Start() {
        scale = transform.localScale.x;
        animator = GetComponent<Animator>();
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
        if (Physics.Raycast(transform.position + (Vector3.down * 1.2f), Vector3.down * 0.1f)) {
            SetJump();
        } else if (lastX - transform.position.x < -0.002 || lastX - transform.position.x > 0.002) {
            SetWalk();
        } else {
            SetIdle();
        }

        // Record last x
        lastX = transform.position.x;
    }
    
    public void SetJump() {
        foreach (Animator animator in gameObject.GetComponentsInChildren<Animator>()) {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", true);
        }
    }
    
    public void SetWalk() {
        foreach (Animator animator in gameObject.GetComponentsInChildren<Animator>()) {
            animator.SetBool("Idle", false);
            animator.SetBool("Walk", true);
            animator.SetBool("Jump", false);
        }
    }
    
    public void SetIdle() {
        foreach (Animator animator in gameObject.GetComponentsInChildren<Animator>()) {
            animator.SetBool("Idle", true);
            animator.SetBool("Walk", false);
            animator.SetBool("Jump", false);
        }
    }
    
    public void OnDrawGizmos() {
        Gizmos.DrawRay(transform.position + (Vector3.down * 1.2f), Vector3.down * 0.1f);
    }

}
