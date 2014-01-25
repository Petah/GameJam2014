using UnityEngine;
using System.Collections;

public class PlayerAnimator : MonoBehaviour {

	private Animator animator;
	private MeleeAttack meleeAttack;

	public void Start () {
		animator = gameObject.GetComponent<Animator> ();
		meleeAttack = gameObject.GetComponent<MeleeAttack> ();
	}
	
	public void Update () {
		animator.SetFloat("swing", meleeAttack.CurrentSwing);
		Debug.Log (meleeAttack.CurrentSwing);
	}
}
