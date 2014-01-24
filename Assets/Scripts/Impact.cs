using UnityEngine;
using System.Collections;

public class Impact {
    
    public Vector3 direction;
    public float force;
    public GameObject from;

    public Impact(Vector3 direction, float force, GameObject from) {
        this.direction = direction;
        this.force = force;
        this.from = from;
    }

}
