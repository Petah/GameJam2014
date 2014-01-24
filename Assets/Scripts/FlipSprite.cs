using UnityEngine;
using System.Collections;

public class FlipSprite : MonoBehaviour {

    private float lastX = 0;
    private float scale;

    public void Start() {
        scale = transform.localScale.x;
    }
	
	public void Update () {
        Vector3 localScale = transform.localScale;
        if (transform.position.x < lastX) {
            localScale.x = -scale;
        } else if (transform.position.x > lastX) {
            localScale.x = scale;
        }
        transform.localScale = localScale;
        lastX = transform.position.x;
	}

}
