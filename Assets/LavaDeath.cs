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
            GameObject respawn = GameObject.FindGameObjectWithTag("Respawn");
            transform.gameObject.GetComponent<DwarfAni>().Dead = true;
            transform.position = new Vector3(0, 10000000, 0);
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
