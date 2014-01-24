using UnityEngine;
using System.Collections;

public class FPSInputController : MonoBehaviour {
    
    public string horizontal;
    public string vertical;
    public string jump;
    public string attack;
    public string shoot;
    public string taunt;

    private CharacterMotor motor;
	private Weapon weapon;
	
	public void Awake() {
		motor = GetComponent<CharacterMotor>();
		weapon = GetComponent<Weapon>();
	}
	
    public void Update() {
        // Get the input vector from keyboard or analog stick
        Vector3 directionVector = new Vector3(Input.GetAxis(horizontal), 0, 0);
        
        if (directionVector != Vector3.zero) {
            // Get the length of the directon vector and then normalize it
            // Dividing by the length is cheaper than normalizing when we already have the length anyway
            float directionLength = directionVector.magnitude;
            directionVector = directionVector / directionLength;
            
            // Make sure the length is no bigger than 1
            directionLength = Mathf.Min(1, directionLength);
            
            // Make the input vector more sensitive towards the extremes and less sensitive in the middle
            // This makes it easier to control slow speeds when using analog sticks
            directionLength = directionLength * directionLength;
            
            // Multiply the normalized direction vector by the modified length
            directionVector = directionVector * directionLength;
        }
        
        // Apply the direction to the CharacterMotor
        motor.inputMoveDirection = transform.rotation * directionVector;
        motor.inputJump = Input.GetButton(jump);
		
		if (Input.GetButton(shoot)) {
			if (weapon != null && weapon.CanAttack) {
				weapon.Attack(true);
				//add sound in here later
			}
		}
		//Input.GetButton(attack);
        //Input.GetButton(shoot);
        //Input.GetButton(taunt);
    }

}