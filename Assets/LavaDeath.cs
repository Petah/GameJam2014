using UnityEngine;
using System.Collections;

public class LavaDeath : MonoBehaviour {

    public void Update () {
	    if (transform.position.y < Camera.main.transform.position.y - 4) {
            Vector3 position = transform.position;
            position.y += 10;
            transform.position = position;
        }
	}

}
