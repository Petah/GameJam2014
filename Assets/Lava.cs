using UnityEngine;
using System.Collections;

public class Lava : MonoBehaviour {

    public Vector3 cameraDiff;
    public Camera followCamera;

	public void Start () {
        cameraDiff = transform.position - followCamera.transform.position;
	}
	
	public void Update () {
        transform.position = followCamera.transform.position + cameraDiff;
	}
}
