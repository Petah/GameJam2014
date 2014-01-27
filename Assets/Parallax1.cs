using UnityEngine;
using System.Collections;


public class Parallax1 : MonoBehaviour {
	public float maxHeight = 40;

	public void Update () {
		if (transform.position.y < maxHeight) {
						Vector3 position = transform.position;
						position.y -= 0.003f;
						transform.position = position;
				}
	}

}
