using UnityEngine;
using System.Collections;

public class IgnorePlayerCollision : MonoBehaviour {

	public void Start () {
        foreach (GameObject player in GameObject.FindGameObjectsWithTag("Player")) {
            Physics.IgnoreCollision(collider, player.collider);
        }
	}
	
}
