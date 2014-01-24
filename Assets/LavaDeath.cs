using UnityEngine;
using System.Collections;

public class LavaDeath : MonoBehaviour {

    private int respawning = -1;
    public int Respawning { 
        get {
            return respawning;
        }
    }

    public void FixedUpdate() {
        if (respawning > 0) {
            respawning--;
            transform.position = new Vector3(-10000, -10000);
        } else if (respawning == 0) {
            // Respawn at top of map
            transform.position = new Vector3(Camera.main.transform.position.x, Camera.main.transform.position.y + 5);
            respawning = -1;
        } else if (transform.position.y < Camera.main.transform.position.y - 4) {
            Vector3 position = transform.position;
            position.y += 10;
            transform.position = position;
            respawning = 100;
            gameObject.SendMessage("Death", null, SendMessageOptions.DontRequireReceiver);
        }
	}

}
