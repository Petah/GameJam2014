using UnityEngine;
using System.Collections;

public class GivesDamage : MonoBehaviour {

	public void OnCollisionEnter(Collision collision) {
		collision.gameObject.SendMessage ("Damage", 1, SendMessageOptions.DontRequireReceiver);
	}
}
