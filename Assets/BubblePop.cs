using UnityEngine;
using System.Collections;

public class BubblePop : MonoBehaviour {

    public float timer = 60;

	void FixedUpdate () {
        timer--;
        if (timer <= 0) {
            Destroy(gameObject);
        }
	}
}
