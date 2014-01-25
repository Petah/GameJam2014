using UnityEngine;
using System.Collections;

public class ParallaxBG : MonoBehaviour {

    public float speed = 1;

	public void Update() {
        Vector3 position = transform.position;
        position.y += Time.deltaTime * speed;
        transform.position = position;
	}
}
