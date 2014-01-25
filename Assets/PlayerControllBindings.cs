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
        Debug.Log("test");
        CreatePlayer(1);
        CreatePlayer(2);
        CreatePlayer(3);
        CreatePlayer(4);
    }

    public void CreatePlayer(int player) {
        players[player - 1] = Instantiate(playerPrefab, new Vector3(0f, 10000000f, 0f), Quaternion.identity) as GameObject;
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
