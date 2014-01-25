using UnityEngine;
using System.Collections;

public class JumpThrough : MonoBehaviour {

    GameObject[] players;
    void Start () {
        players = GameObject.FindGameObjectsWithTag("Player");
	}
	
    void Update () {
        foreach (GameObject player in players) {
            if (player.transform.position.y < transform.position.y) {
                Physics.IgnoreCollision(collider, player.collider);
            } else {
                Physics.IgnoreCollision(collider, player.collider, false);
            }
        }
	}
}
