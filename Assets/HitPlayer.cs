using UnityEngine;
using System.Collections;

public class HitPlayer : MonoBehaviour {

    private float distance = 0.1f;
    public GameObject explosion;

    public void FixedUpdate() {
        if (CheckRaycast(Physics.RaycastAll(
                    new Vector3(transform.position.x - distance, transform.position.y - distance, 0), 
                    new Vector3(distance * 2, distance * 2), 
                    distance
                ))) {
            return;
        }
        if (CheckRaycast(Physics.RaycastAll(
                    new Vector3(transform.position.x - distance, transform.position.y + distance, 0), 
                    new Vector3(distance * 2, -distance * 2), 
                    distance
                ))) {
            return;
        }
    }

    public bool CheckRaycast(RaycastHit[] raycastHits) {
        foreach (RaycastHit raycastHit in raycastHits) {
            if (raycastHit.transform.gameObject.tag == "Player") {
                Debug.Log(raycastHit.transform.gameObject.name);
                Debug.Log(explosion);
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
                return true;
            }
        }
        return false;
    }
    
    public void OnDrawGizmos() {
        Vector3 position;
        position = transform.position;
        Gizmos.DrawRay(new Vector3(position.x - distance, position.y - distance, 0), new Vector3(distance * 2, distance * 2));
        Gizmos.DrawRay(new Vector3(position.x - distance, position.y + distance, 0), new Vector3(distance * 2, -distance * 2));
    }

}
