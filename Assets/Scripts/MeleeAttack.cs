using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    private DwarfAni da;

    private Vector3 center = new Vector3(0, -0.3f, 0);

    private int swingReload = 0;
    private int swingReloadTime = 30;
    private float swingPosition;
    private float swingStart = -1.4f;
    private float swingEnd = 1.6f;
    private float swingRange = 1.2f;

    private int punchReload = 0;
    private int punchReloadTime = 10;
    private float punchPosition;
    private float punchStart = 0;
    private float punchEnd = 1;
    
    public float CurrentSwing {
        get { return swingPosition; }
    }

    public void Awake() {
        da = GetComponent<DwarfAni>();
    }
    
    public void Punch() {
        if (!CanAttack()) {
            return;
        }
        punchPosition = punchStart;
        punchReloadTime = punchReloadTime;
    }

    public void Swing() {
        if (!CanAttack()) {
            return;
        }
        swingPosition = swingStart;
        swingReloadTime = swingReloadTime;
    }

    public bool CanAttack() {
        return swingReload == 0 && punchReload == 0 && swingPosition >= swingEnd && punchPosition >= punchEnd;
    }
    
    public void FixedUpdate() {
        if (swingReload > 0) {
            swingReload--;
            return;
        }
        if (punchReload > 0) {
            punchReload--;
            return;
        }
        if (swingPosition <= swingEnd) {
            foreach (RaycastHit raycastHit in Physics.RaycastAll(transform.position + center, GetDirection(), swingRange)) {
                if (raycastHit.transform.gameObject.tag == "Player") {
                    Vector3 impactDirection;
                    if (raycastHit.transform.position.x > transform.position.x) {
                        impactDirection = Vector3.right;
                    } else {
                        impactDirection = Vector3.left;
                    }
                    raycastHit.transform.gameObject.SendMessage("AddImpact", new Impact(impactDirection, 30, gameObject), SendMessageOptions.DontRequireReceiver);
                    swingPosition = 1000f;
                }
            }

            swingPosition += 0.3f;
        }
    }

    public Vector3 GetDirection() {
        Vector3 position = transform.position;
        position.x = Mathf.Cos(swingPosition) / 2;
        position.y = Mathf.Sin(-swingPosition) / 2 - 0.3f;
        position.x *= da.Direction;
        position = transform.position + position;
        
        return (position - (transform.position + center)).normalized;
    }

    public void OnDrawGizmos() {
        if (da) {
            if (swingPosition <= swingEnd) {
                Gizmos.DrawRay(transform.position + center, GetDirection() * swingRange);
            }
            Gizmos.DrawRay(transform.position + center, Vector3.right * da.Direction);
        }
    }

    public bool IsSwiging() {
        return swingPosition <= swingEnd;
    }

}
