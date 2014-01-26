using UnityEngine;
using System.Collections;

public class FPSInputController : MonoBehaviour {
    
    public string horizontal;
    public string vertical;
    public string jump;
    public string attack;
    public string shoot;
    public string taunt;
    public string run;

    public AudioClip[] taunts;
    private int tauntIndex = 0;
    private int tauntDelay = 0;

    private CharacterMotor motor;
    private Weapon weapon;
    private MeleeAttack melee;
    private HoldingPickup holdingPickup;
    private Direction playerDirection;
    private DwarfAni ani;
	
	public void Awake() {
        motor = GetComponent<CharacterMotor>();
        weapon = GetComponent<Weapon>();
        melee = GetComponent<MeleeAttack>();
        holdingPickup = GetComponent<HoldingPickup>();
        playerDirection = transform.GetComponent<Direction>();
        ani = transform.GetComponent<DwarfAni>();
	}
	
    public void Update() {
        if (ani != null && ani.lastHit != null && ani.lastHit.swing) {
            return;
        }

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
            if (holdingPickup.IsHolding()) {
                holdingPickup.Throw(transform.position, playerDirection.Dir);
            }
			if (weapon != null && weapon.CanAttack) {
				weapon.Attack(true);
				//add sound in here later
			}
        }
        
        if (Input.GetButton(attack)) {
            melee.Swing();
        }
        
        if (Input.GetButton(shoot)) {
            melee.Punch();
        }
        
        if (Input.GetButton(shoot)) {
            melee.Punch();
        }
        
        if (Input.GetButton(taunt) && tauntDelay <= 0) {
            tauntDelay = 50;
            audio.PlayOneShot(taunts[Random.Range(0, taunts.Length)]);
        }
        tauntDelay--;
        
    }

}