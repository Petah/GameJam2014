using UnityEngine;
using System.Collections;

public class Direction : MonoBehaviour {
    
    private float lastX = 0;
    private float dir = 1;
    
    public float Dir { 
        get {
            return dir; 
        }
    }
    
    public void Update () {
        if (transform.position.x < lastX) {
            dir = -1;
        } else if (transform.position.x > lastX) {
            dir = 1;
        }
        lastX = transform.position.x;
    }

}
