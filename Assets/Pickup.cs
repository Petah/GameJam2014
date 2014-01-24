using UnityEngine;
using System.Collections;

public class Pickup : MonoBehaviour {

    public GameObject[] players;

    public void Start() {
        players = GameObject.FindGameObjectsWithTag("Player");
    }

    public void FixedUpdate() {
        foreach (GameObject player in players) {
            float distance = Vector3.Distance(transform.position, player.transform.position);
            if (distance < 1) {
//                Destroy(gameObject);
            }
        }
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag.Equals("Player")) {
            Debug.Log(collision);
            Destroy(gameObject);
        }
    }

}
