using UnityEngine;
using System.Collections;

public class ParallaxBG : MonoBehaviour {

    public float speed = 1;
	public float maxHeight = 1;

	public void Update() {
		if (transform.position.y < maxHeight) {
						Vector3 position = transform.position;
						position.y += Time.deltaTime * speed;
						transform.position = position;
				}
	}
}
