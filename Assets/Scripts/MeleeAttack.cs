using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    private DwarfAni da;
    
    private Vector3 punchOffset = new Vector3(0.95f, -0.6f, 0);
    private Vector3 swingOffset = new Vector3(0.85f, -0.6f, 0);
    
    public bool swinging = false;
    public bool punching = false;

    public void Awake() {
        da = GetComponent<DwarfAni>();
    }

    public void PunchHit() {
        punching = false;

        foreach (RaycastHit hit in Physics.RaycastAll(transform.position + new Vector3(punchOffset.x * da.Direction, punchOffset.y), new Vector3(punchOffset.x * da.Direction), 0.2f)) {
            Debug.Log(hit.rigidbody.gameObject.name);
        }
    }
    
    public void SwingHit() {
        swinging = false;


    }
    
    public void Punch() {
        if (!CanAttack()) {
            return;
        }
        punching = true;
    }
    
    public void Swing() {
        if (!CanAttack()) {
            return;
        }
        swinging = true;
    }
    
    public bool IsSwinging() {
        return swinging;
    }
    
    public bool IsPunching() {
        return punching;
    }

    public bool CanAttack() {
        return !punching && !swinging;
    }

    public void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawSphere(transform.position + new Vector3(punchOffset.x * da.Direction, punchOffset.y), 0.2f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position + new Vector3(swingOffset.x * da.Direction, swingOffset.y), 0.2f);
    }

}
