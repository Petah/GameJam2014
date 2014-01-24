using UnityEngine;
using System.Collections;

public class MeleeAttack : MonoBehaviour {

    public void Start() {
    
    }
    
    public void Update() {
    
    }

    public void OnDrawGizmosSelected() {
        Gizmos.color = Color.yellow;
        Vector3 position = transform.position;
        for (float i = 0; i < 0.6; i += 0.1f) {
            position.x = Mathf.Cos(i);
            position.y = Mathf.Sin(i);
            Gizmos.DrawSphere(position, 0.1f);
        }
    }

}
