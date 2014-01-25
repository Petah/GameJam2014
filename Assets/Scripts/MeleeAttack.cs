using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    private DwarfAni da;

    private Vector3 center = new Vector3(0, -0.3f, 0);

    private int swingReload = 0;
    private int swingReloadTime = 30;
    private float swingForce = 100;
    private float swingPosition = 1000;
    private float swingStart = -1.4f;
    private float swingEnd = 1.6f;
    private float swingRange = 1.2f;

    private int punchReload = 0;
    private int punchReloadTime = 10;
    private float punchForce = 100;
    private float punchPosition = 1000;
    private float punchStart = 0.01f;
    private float punchEnd = 2;
    
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
        punchReload = punchReloadTime;
    }
    
    public bool IsPunching() {
        return punchPosition <= punchEnd;
    }

    public void Swing() {
        if (!CanAttack()) {
            return;
        }
        swingPosition = swingStart;
        swingReload = swingReloadTime;
    }

    public bool IsSwinging() {
        return swingPosition <= swingEnd;
    }

    public bool CanAttack() {
        return swingReload == 0 && punchReload == 0 && swingPosition >= swingEnd && punchPosition >= punchEnd;
    }
    
    public void FixedUpdate() {
        if (swingReload > 0) {
            swingReload--;
        }
        if (punchReload > 0) {
            punchReload--;
        }
        if (swingPosition <= swingEnd) {
            foreach (RaycastHit raycastHit in Physics.RaycastAll(transform.position + center, GetDirection(), swingRange)) {
                SendImpact(raycastHit, swingForce);
            }
                swingPosition += 0.3f;
        } else if (punchPosition <= punchEnd) {
            foreach (RaycastHit raycastHit in Physics.RaycastAll(transform.position + center, Vector3.right * da.Direction, punchPosition)) {
                SendImpact(raycastHit, punchForce);
            }
            punchPosition += 0.3f;
        }
    }

    public void SendImpact(RaycastHit raycastHit, float force) {
        Vector3 impactDirection;
        if (raycastHit.transform.position.x > transform.position.x) {
            impactDirection = Vector3.right;
        } else {
            impactDirection = Vector3.left;
        }
        raycastHit.transform.gameObject.SendMessage("AddImpact", new Impact(impactDirection, force, gameObject), SendMessageOptions.DontRequireReceiver);
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
            if (IsSwiging()) {
                Gizmos.DrawRay(transform.position + center, GetDirection() * swingRange);
            }
            if (IsPunching()) {
                Gizmos.DrawRay(transform.position + center, Vector3.right * punchPosition * da.Direction);
            }
        }
    }

    public bool IsSwiging() {
        return swingPosition <= swingEnd;
    }

}
