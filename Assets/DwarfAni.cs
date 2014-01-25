using UnityEngine;
using System.Collections;

public class DwarfAni : MonoBehaviour {
    
    public Transform follow;

    private Animator animator;
    
    private float lastX = 0;
    private float scale;
    private float direction = 1;

    public void Start() {
        scale = transform.localScale.x;
        animator = GetComponent<Animator>();
    }
    
    public void Update () {
        // Follow
        transform.position = follow.position;
    
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

        // Animate
        animator.SetFloat("swing", 7f);

        if (lastX - transform.position.x < -0.01 || lastX - transform.position.x > 0.01) {
            Debug.Log(true);
            animator.SetBool("move", true);
        } else {
            Debug.Log(false);
            animator.SetBool("move", false);
        }

        // Record last x
        lastX = transform.position.x;
    }

}
