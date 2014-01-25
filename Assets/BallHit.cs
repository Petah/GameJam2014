using UnityEngine;
using System.Collections;

public class BallHit : MonoBehaviour {
    
    public void AddImpact(Impact incoming) {
        incoming.direction.Normalize();
        if (incoming.direction.y < 0) {
            incoming.direction.y = -incoming.direction.y;
        }
        rigidbody.AddForce(incoming.direction.normalized * incoming.force);
    }

}
