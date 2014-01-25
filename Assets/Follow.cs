using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    public Transform follow;

    public void Update() {
        transform.position = follow.position;
    }

}
