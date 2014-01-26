using UnityEngine;
using System.Collections;

public class AnimateEvents : MonoBehaviour {
    
    private MeleeAttack melee;
    private DwarfAni ani;

    public void Start() {
        melee = transform.parent.GetComponent<MeleeAttack>();
        ani = transform.parent.GetComponent<DwarfAni>();
    }

    public void PunchHit() {
        melee.PunchHit();
    }
    
    public void SwingHit() {
        melee.SwingHit();
    }
    
    public void SwingEnd() {
        melee.SwingEnd();
    }
    
    public void FinishFall() {
        ani.FinishFall();
    }
    
    public void Die() {
        ani.Die();
    }
}
