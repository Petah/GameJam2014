using UnityEngine;
using System.Collections;

public class UIOverlay : MonoBehaviour {

    public Texture player1Head;
    public Texture player2Head;
    public Texture player3Head;
    public Texture player4Head;
    public Texture kill;
    public Texture item;
    
    /*
    public Texture player1Head;
    public Texture player2Head;
    public Texture player3Head;
    public Texture player4Head;
    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;
    public LavaDeath player1Respawn;
    public LavaDeath player2Respawn;
    public LavaDeath player3Respawn;
    public LavaDeath player4Respawn;
    public KillCounter player1KillCounter;
    public KillCounter player2KillCounter;
    public KillCounter player3KillCounter;
    public KillCounter player4KillCounter;
    */

    public void Start() {
        /*
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Player")) {
            if (gameObject.name == "Player1") {
                player1 = gameObject;
                player1Respawn = player1.GetComponent<LavaDeath>();
                player1KillCounter = player1.GetComponent<KillCounter>();
            } else if (gameObject.name == "Player2") {
                player2 = gameObject;
                player2Respawn = player2.GetComponent<LavaDeath>();
                player2KillCounter = player2.GetComponent<KillCounter>();
            } else if (gameObject.name == "Player3") {
                player3 = gameObject;
                player3Respawn = player3.GetComponent<LavaDeath>();
                player3KillCounter = player3.GetComponent<KillCounter>();
            } else if (gameObject.name == "Player4") {
                player4 = gameObject;
                player4Respawn = player4.GetComponent<LavaDeath>();
                player4KillCounter = player4.GetComponent<KillCounter>();
            }
        }
        */
    }
    
    /*
    public string GetGUIText(LavaDeath respawn, KillCounter killCounter) {
        string result = "";
        if (respawn && respawn.Respawning > 0) {
            result += "Respawning in: " + respawn.Respawning;
        }
        if (killCounter) {
            result += "Kill counter: " + killCounter.KillCounts.Count;
        }
        return result;
    }
    */

    public void OnGUI() {
        int width = 136;
        int height = 136;
        GUI.DrawTexture(new Rect(0, 0, width, height), player4Head);
        GUI.DrawTexture(new Rect(90, 39, 54, 52), item);
        GUI.DrawTexture(new Rect(135, 41, 26, 28), kill);
        GUI.DrawTexture(new Rect(135 + 15, 41, 26, 28), kill);
        GUI.DrawTexture(new Rect(135 + 15 * 2, 41, 26, 28), kill);

        GUI.DrawTexture(new Rect(Screen.width - width, 0, width, height), player3Head);

        GUI.DrawTexture(new Rect(0, Screen.height - height, width, height), player2Head);

        GUI.DrawTexture(new Rect(Screen.width - width, Screen.height - height, width, height), player1Head);



        /*
        int width = 150;
        GUI.Box(new Rect(0, 0, width, 50), GetGUIText(player1Respawn, player1KillCounter));
        GUI.Box(new Rect(Screen.width - width, 0, width, 50), GetGUIText(player2Respawn, player2KillCounter));
        GUI.Box(new Rect(0, Screen.height - 50, width, 50), GetGUIText(player3Respawn, player3KillCounter));
        GUI.Box(new Rect(Screen.width - width, Screen.height - 50, width, 50), GetGUIText(player4Respawn, player4KillCounter));

        int x;
        x = 0;
        foreach (GameObject gameObject in player1KillCounter.KillCounts) {
            x += 15;
            GUI.DrawTexture(new Rect(x, 15, 15, 31), player1Head);
        }
        if (player2KillCounter) {
            x = 0;
            foreach (GameObject gameObject in player2KillCounter.KillCounts) {
                x += 15;
                GUI.DrawTexture(new Rect(Screen.width - width + x, 15, 15, 31), player1Head);
            }
        }
        if (player3KillCounter) {
            x = 0;
            foreach (GameObject gameObject in player3KillCounter.KillCounts) {
                x += 15;
                GUI.DrawTexture(new Rect(x, 15, Screen.height - 50, 31), player1Head);
            }
        }
        if (player4KillCounter) {
            x = 0;
            foreach (GameObject gameObject in player4KillCounter.KillCounts) {
                x += 15;
                GUI.DrawTexture(new Rect(Screen.width - width + x, 15, Screen.height - 50, 31), player1Head);
            }
        }
        */
    }

}

