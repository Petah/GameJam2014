using UnityEngine;
using System.Collections;

public class DestroyBelowCamera : MonoBehaviour {
	
	public void Update() {
        if (transform.position.y - Camera.main.transform.position.y < -6) {
            Destroy(gameObject);
        }
	}
}
