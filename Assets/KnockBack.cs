using UnityEngine;
using System.Collections;

public class KnockBack : MonoBehaviour {

    private float mass = 3.0f;
    private Vector3 impact = Vector3.zero;
    private CharacterController character;
    
    public void Start() {
        character = GetComponent<CharacterController>();
    }
    
    public void AddImpact(Impact incoming) {
        Debug.Log("test");
        incoming.direction.Normalize();
        if (incoming.direction.y < 0) {
            incoming.direction.y = -incoming.direction.y; // reflect down force on the ground
        }
        impact += incoming.direction.normalized * incoming.force / mass;
    }
    
    public void Update() {
        // apply the impact force:
        if (impact.magnitude > 0.2f) {
            character.Move(impact * Time.deltaTime);
        }
        // consumes the impact energy each cycle:
        impact = Vector3.Lerp(impact, Vector3.zero, 5 * Time.deltaTime);
    }
}