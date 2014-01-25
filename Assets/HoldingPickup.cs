using UnityEngine;
using System.Collections;

public class HoldingPickup : MonoBehaviour {

    private bool holding = false;
    public GameObject projectilePrefab;

    public bool Holding {
        get { return holding; }
        set { holding = value; }
    }

    public bool IsHolding() {
        return holding;
    }

    public void Throw(Vector3 position, float direction) {
        holding = false;
        GameObject projectile = Instantiate(projectilePrefab, position, Quaternion.identity) as GameObject;
        float powerX = 300f;
        float powerY = 150f;
        projectile.rigidbody.AddForce(powerX * direction, powerY, 0f);
    }

}
