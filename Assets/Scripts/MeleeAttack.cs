using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    private Transform hitSphere;
    private FlipSprite flipSprite;
    private float i;
    private float range = 0.6f;
    private Vector3 center = new Vector3(0, -0.3f, 0);
    
    public void Awake() {
        hitSphere = transform.Find("HitSphere");
        flipSprite = transform.Find("Sprite").GetComponent<FlipSprite>();
    }

    public void Attack() {
        if (i >= range) {
            i = -1.4f;
        }
    }
    
    public void FixedUpdate() {
        if (i <= range && flipSprite) {
            Vector3 position = transform.position;
            position.x = Mathf.Cos(i) / 2;
            position.y = Mathf.Sin(-i) / 2 - 0.3f;
            position.x *= flipSprite.Direction;
            hitSphere.position = transform.position + position;
            
            Vector3 direction = (hitSphere.position - (transform.position + center)).normalized;
            foreach (RaycastHit raycastHit in Physics.RaycastAll(transform.position + center, direction, 0.5f)) {
                if (raycastHit.transform.gameObject.tag == "Player") {
                    raycastHit.transform.gameObject.SendMessage("AddImpact", new Impact(direction, 30, gameObject), SendMessageOptions.DontRequireReceiver);
                    //raycastHit.transform.rigidbody.AddForce(1 * flipSprite.Direction, 0.1f, 0);
                    i += 3f;
                }
            }

            i += 0.3f;
        } else {

        }
    }

    
    public void OnDrawGizmosSelected() {
        if (hitSphere) {
            Vector3 direction = (hitSphere.position - (transform.position + center)).normalized;
            Gizmos.DrawRay(transform.position + center, direction);
        }
    }

    /*
    public void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Vector3 position = transform.position;
        for (float i = -0.6f; i < Mathf.PI / 2.4f; i += 0.3f) {
            position.x = Mathf.Cos(i) / 2;
            position.y = Mathf.Sin(i) / 2 + 1;
            Gizmos.DrawSphere(position, 0.1f);
        }
    }
    */

}
