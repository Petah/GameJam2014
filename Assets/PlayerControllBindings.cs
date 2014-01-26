using UnityEngine;
using System.Collections;

public class PlayerControllBindings : MonoBehaviour {

    public GameObject playerPrefab;
    
    public RuntimeAnimatorController[] bodyControllers;
    public RuntimeAnimatorController[] armControllers;
    public RuntimeAnimatorController[] legControllers;
    
    private string horizontal = "Horizontal";
    private string vertical = "Vertical";
    private string a = "A";
    private string b = "B";
    private string x = "X";
    private string y = "Y";
    private string rt = "RT";

    private GameObject[] players = new GameObject[4];

    public GameObject[] Players {
        get { return players; }
    }

    public void Start() {
        GameObject[] spawns = GameObject.FindGameObjectsWithTag("Spawn");
        CreatePlayer(1, spawns[0]);
        CreatePlayer(2, spawns[1]);
        CreatePlayer(3, spawns[2]);
        CreatePlayer(4, spawns[3]);

        InvokeRepeating("Respawn", 1f, 1f);
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
        
        players[player - 1].transform.Find("Body").GetComponent<Animator>().runtimeAnimatorController = bodyControllers[player - 1];
        players[player - 1].transform.Find("Arms").GetComponent<Animator>().runtimeAnimatorController = armControllers[player - 1];
        players[player - 1].transform.Find("Legs").GetComponent<Animator>().runtimeAnimatorController = legControllers[player - 1];
    }

    public void Respawn() {
        int i = 0;
        foreach (GameObject player in players) {
            DwarfAni ani = player.GetComponent<DwarfAni>();
            if (ani.Dead) {
                GameObject min = null;
                foreach (GameObject spawn in GameObject.FindGameObjectsWithTag("UpSpawn")) {
                    if (spawn.transform.position.y > Camera.main.transform.position.y) {
                        if (min == null || spawn.transform.position.y < min.transform.position.y) {
                            min = spawn;
                        }
                    }
                }
                if (min != null) {
                    ani.Dead = false;
                    player.transform.position = min.transform.position;
                }
            }
            i++;
        }
    }

}
