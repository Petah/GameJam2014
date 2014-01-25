using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    private FlipSprite flipSprite;
    private float i;
    private float swing = 3.6f;
    private float range = 1.2f;
    private Vector3 center = new Vector3(0, -0.3f, 0);
    private Vector3 direction = Vector3.zero;
    private int reload = 0;
    
	public float CurrentSwing {
		get { return i; }
	}

    public void Awake() {
        flipSprite = transform.Find("Sprite").GetComponent<FlipSprite>();
    }

    public void Attack() {
        if (i >= swing && reload == 0) {
            i = -1.4f;
            reload = 30;
        }
    }
    
    public void FixedUpdate() {
        if (reload > 0) {
            reload--;
        }
        if (i <= swing) {
            foreach (RaycastHit raycastHit in Physics.RaycastAll(transform.position + center, GetDirection(), range)) {
                if (raycastHit.transform.gameObject.tag == "Player") {
                    Vector3 impactDirection;
                    if (raycastHit.transform.position.x > transform.position.x) {
                        impactDirection = Vector3.right;
                    } else {
                        impactDirection = Vector3.left;
                    }
                    raycastHit.transform.gameObject.SendMessage("AddImpact", new Impact(impactDirection, 30, gameObject), SendMessageOptions.DontRequireReceiver);
                    i = 1000f;
                }
            }

            i += 0.3f;
        }
    }

    public Vector3 GetDirection() {
        Vector3 position = transform.position;
        position.x = Mathf.Cos(i) / 2;
        position.y = Mathf.Sin(-i) / 2 - 0.3f;
        position.x *= flipSprite.Direction;
        position = transform.position + position;
        
        return (position - (transform.position + center)).normalized;
    }

    public void OnDrawGizmos() {
        if (i <= swing && flipSprite) {
            Gizmos.DrawRay(transform.position + center, GetDirection() * range);
        }
    }

    public bool IsSwiging() {
        return i <= swing;
    }

}
