using UnityEngine;
using System.Collections;

public class IgnorePlayerCollision : MonoBehaviour {

	public void Start () {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            if (collider != player.collider) {
                Physics.IgnoreCollision(collider, player.collider);
            }
        }
	}
	
}
