using UnityEngine;
using System.Collections;

public class AnimateEvents : MonoBehaviour {

    private MeleeAttack melee;

    public void Start() {
        melee = transform.parent.GetComponent<MeleeAttack>();
    }

    public void PunchHit() {
        melee.PunchHit();
    }

    public void SwingHit() {
        melee.SwingHit();
    }
}
