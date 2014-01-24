using UnityEngine;
using System.Collections;

public class TakesDamage : MonoBehaviour {

	float health = 20;

	public void Damage(float damage) {
				health -= damage;
				if (health <= 0) {
						Destroy (gameObject);

				}
		}
}
