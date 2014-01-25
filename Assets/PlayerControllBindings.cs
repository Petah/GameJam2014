using UnityEngine;
using System.Collections;

public class PlayerControllBindings : MonoBehaviour {

    public GameObject playerPrefab;
    
    private string horizontal = "Horizontal";
    private string vertical = "Vertical";
    private string a = "A";
    private string b = "B";
    private string x = "X";
    private string y = "Y";
    private string rt = "RT";

    private GameObject[] players = new GameObject[4];

    public void Start() {
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("Spawn");
        CreatePlayer(1, spawns[0]);
        CreatePlayer(2, spawns[1]);
        CreatePlayer(3, spawns[2]);
        CreatePlayer(4, spawns[3]);
    }

    public void CreatePlayer(int player, GameObject spawn) {
        players[player - 1] = Instantiate(playerPrefab, spawn.transform.position, Quaternion.identity) as GameObject;
        FPSInputController controller = players[player - 1].GetComponent<FPSInputController>();
        controller.horizontal = horizontal + player;
        controller.vertical = vertical + player;
        controller.jump = a + player;
        controller.attack = b + player;
        controller.shoot = x + player;
        controller.taunt = y + player;
        controller.run = rt + player;
    }

}
