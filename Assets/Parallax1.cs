using UnityEngine;
using System.Collections;

public class Parallax1 : MonoBehaviour {

	public void Update () {
        Vector3 position = transform.position;
        position.y -= 0.003f;
        transform.position = position;
	}

}
