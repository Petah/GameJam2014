using UnityEngine;
using System.Collections;

public class Impact {
    
    public Vector3 direction;
    public float force;

    public Impact(Vector3 direction, float force) {
        this.direction = direction;
        this.force = force;
    }

}
