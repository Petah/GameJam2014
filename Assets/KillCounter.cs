using UnityEngine;
using System.Collections;

public class KillCounter : MonoBehaviour {

    private int killCount;
    public int KillCount {
        get {
            return killCount;
        }
    }

	public void Start () {
        killCount = Mathf.FloorToInt(Random.Range(0, 10));
	}
	
}
