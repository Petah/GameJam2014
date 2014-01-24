using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KillCounter : MonoBehaviour {

    private List<GameObject> killCounts;
    private int hitTimer = 0;
    private GameObject lastHit;

    public List<GameObject> KillCounts {
        get { return killCounts; }
    }

    public void Start () {
        killCounts = new List<GameObject>();
	}
	
    public void FixedUpdate() {
        if (hitTimer > 0) {
            hitTimer--;
        } else if (hitTimer == 0) {
            lastHit = null;
            hitTimer = -1;
        }
    }
    
    public void AddImpact(Impact incoming) {
        lastHit = incoming.from;
        hitTimer = 100;
    }

    public void Death() {
        if (lastHit != null) {
            lastHit.GetComponent<KillCounter>().killCounts.Add(gameObject);
        }
    }

}
