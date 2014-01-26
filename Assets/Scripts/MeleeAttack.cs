using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {
    
    public AudioClip swingHit;
    public AudioClip swingHit2;
    public AudioClip swingMiss;
    public AudioClip punchHit1;
    public AudioClip punchHit2;
    public AudioClip punchHit3;

    private DwarfAni da;
    private Vector3 punchOffset = new Vector3(0, -0.6f, 0);
    private Vector3 swingOffset = new Vector3(0.85f, -0.6f, 0);
    public bool swinging = false;
    public bool punching = false;

    public void Awake() {
        da = GetComponent<DwarfAni>();
    }

    public void PunchHit() {
        punching = false;
        
        bool didHit = false;
        foreach (RaycastHit hit in Physics.RaycastAll(
                    transform.position + new Vector3(0.1f * da.Direction, -0.6f), 
                    new Vector3(0.6f * da.Direction, 0), 
                    1f
            )) {
            hit.collider.gameObject.SendMessage("AddImpact", new Impact(gameObject, false), SendMessageOptions.DontRequireReceiver);
            didHit = true;
        }
        if (didHit) {
            audio.PlayOneShot(punchHit1);
            audio.PlayOneShot(punchHit2);
        } else {
            audio.PlayOneShot(punchHit3);
        }
    }
    
    public void SwingHit() {
        bool didHit = false;
        foreach (RaycastHit hit in Physics.RaycastAll(
                    transform.position + new Vector3(0.2f * -da.Direction, -0.6f), 
                    new Vector3(0.6f * da.Direction, 0), 
                    1f
            )) {
            hit.collider.gameObject.SendMessage("AddImpact", new Impact(gameObject, true), SendMessageOptions.DontRequireReceiver);
            didHit = true;
        }
        if (didHit) {
            audio.PlayOneShot(swingHit);
            audio.PlayOneShot(swingHit2);
        } else {
            audio.PlayOneShot(swingMiss);
        }
    }
    
    public void SwingEnd() {
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
    /*
    public void OnDrawGizmos() {
        if (da) {
            Gizmos.DrawRay(
                transform.position + new Vector3(punchOffset.x * da.Direction, punchOffset.y), 
                new Vector3(punchOffset.x * da.Direction, 0) / 2
            );
            return;

            Gizmos.color = Color.red;
            Gizmos.DrawSphere(transform.position + new Vector3(punchOffset.x * da.Direction, punchOffset.y), 0.2f);
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position + new Vector3(swingOffset.x * da.Direction, swingOffset.y), 0.2f);
        }
    }
*/
}
