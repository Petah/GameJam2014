using UnityEngine;
using System.Collections;

public class SpawnLavaBubbles : MonoBehaviour {

    public GameObject large;
    public GameObject small;

    public void Start() {
        InvokeRepeating("SpawnBubble", 1, 0.3F);
    }

    public void SpawnBubble() {
        Vector3 position;
        GameObject bubble;

        position = transform.position;
        position.x = Random.Range(-9, 9);
        position.y += Random.Range(0, 0.1f);
        bubble = Instantiate(large, position, Quaternion.identity) as GameObject;
        bubble.transform.parent = transform;
        
        position = transform.position;
        position.x = Random.Range(-9, 9);
        position.y += Random.Range(0, 0.1f);
        bubble = Instantiate(small, position, Quaternion.identity) as GameObject;
        bubble.transform.parent = transform;
    }

}
