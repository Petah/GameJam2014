using UnityEngine;
using System.Collections;

public class UIOverlay : MonoBehaviour {

    public Texture player1Head;
    public Texture player2Head;
    public Texture player3Head;
    public Texture player4Head;
    public Texture kill;
    public Texture item;
    private PlayerControllBindings pm;

    public void Start() {
        pm = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerControllBindings>();
    }

    public void OnGUI() {
        DwarfAni ani;
        int width = 136;
        int height = 136;

        GUI.DrawTexture(new Rect(0, 0, width, height), player4Head);
        ani = pm.Players[2].GetComponent<DwarfAni>();
        for (int x = 94, i = 0; i < ani.Kills; x += 15, i++) {
            GUI.DrawTexture(new Rect(x, 41, 26, 28), kill);
        }

        GUI.DrawTexture(new Rect(Screen.width - width, 0, width, height), player3Head);
        ani = pm.Players[3].GetComponent<DwarfAni>();
        for (int x = Screen.width - 119, i = 0; i < ani.Kills; x += 15, i++) {
            GUI.DrawTexture(new Rect(x, 41, 26, 28), kill);
        }

        GUI.DrawTexture(new Rect(0, Screen.height - height, width, height), player2Head);
        ani = pm.Players[1].GetComponent<DwarfAni>();
        for (int x = 94, i = 0; i < ani.Kills; x += 15, i++) {
            GUI.DrawTexture(new Rect(x, Screen.height - 54, 26, 28), kill);
        }

        GUI.DrawTexture(new Rect(Screen.width - width, Screen.height - height, width, height), player1Head);
        ani = pm.Players[0].GetComponent<DwarfAni>();
        for (int x = Screen.width - 119, i = 0; i < ani.Kills; x -= 15, i++) {
            GUI.DrawTexture(new Rect(x, Screen.height - 54, 26, 28), kill);
        }

    }

}

