using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    public void Start() {
    
    }
    
    public void Update() {
    
    }

    public void OnGizmoDraw() {
        Gizmos.DrawSphere(transform.position, 1);
    }

}
