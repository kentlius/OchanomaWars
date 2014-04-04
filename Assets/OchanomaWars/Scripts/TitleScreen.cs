using UnityEngine;
using System.Collections;

public class TitleScreen : MonoBehaviour {
    /* 背景 */
    public Texture backGround;

    /* OnGUIで表示するGUIの見た目 */
    public GUIStyle labelStyle = new GUIStyle();
    public Rect labelRect = new Rect(10, 10, Screen.width - 20, 60);
    public string labelMessage = "Game!!";

    public GUIStyle buttonStyle = new GUIStyle();
    public Rect buttonRect = new Rect (Screen.width - 210, Screen.height - 70, 200,
                                       60);
    public string buttonMessage = "Start Game";
    public string buttonStageName = "MainGame";

    /* GUIを表示する */
    void OnGUI() {
        /* 背景が設定されていれば背景を表示する */
        if (backGround) {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height),
                            backGround, ScaleMode.ScaleAndCrop , true, 0.0F);
        }

        /* メッセージを表示する */
        GUI.Label(labelRect, labelMessage, labelStyle);

        /* ステージを切り替えるボタンを表示する */
        if (GUI.Button (buttonRect, buttonMessage, buttonStyle)) {
            Application.LoadLevel(buttonStageName);
        }
    }
}
