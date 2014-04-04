using UnityEngine;
using System.Collections;

public class BatteryPlaceGUI : MonoBehaviour {

    /* 実際に砲台を設置する機能を持つオブジェクト */
    public BatteryPlacer batteryPlacer;

    /* 砲台のプレファブ */
    public GameObject[] batteryPrefabs;
    BatteryController[] batteryInformations;

    /* 砲台を選ぶ画面の大きさ */
    public Vector2 windowSize = new Vector2(Screen.width, Screen.height * 0.3f);
    Rect windowRect;
    /* 砲台を選ぶ画面の背景 */
    public Texture background;
    /* ボタンの大きさ */
    public Vector2 buttonSize = new Vector2(120, 80);
    Rect buttonRect;
    public GUIStyle buttonStyle = new GUIStyle();

    void Start () {
        FetchBatteryInformations();
    }

    /* 砲台の情報を取得する */
    void FetchBatteryInformations () {
        batteryInformations = new BatteryController[batteryPrefabs.Length];
        for(int i = 0; i < batteryPrefabs.Length; i++) {
            batteryInformations[i] = batteryPrefabs[i].GetComponent<BatteryController>();
        }
    }

    /* GUIを表示する */
    void OnGUI () {
        /* 置く砲台がなければこの処理を終える */
        if (batteryPlacer.batteryPrefab != null)
            return;

        /* 砲台を選ぶ画面の大きさを決める */
        windowRect =
            new Rect(0, Screen.height - windowSize.y,
                     windowSize.x, windowSize.y);

        /* 砲台を選ぶ画面を表示する */
        GUI.DrawTexture(windowRect, background, ScaleMode.StretchToFill, true, 0.0F);

        /* 砲台を選ぶボタンを表示する */
        for (int i = 0; i < batteryPrefabs.Length; i++) {
            buttonRect = new Rect(windowRect.xMin + 10 + buttonSize.x * i,
                                  windowRect.yMax - buttonSize.y - 6,
                                  buttonSize.x, buttonSize.y);
            if (batteryInformations[i].cost <= batteryPlacer.mana) {
                if(GUI.Button(buttonRect, batteryInformations[i].availableIcon, buttonStyle)) {
                    batteryPlacer.batteryPrefab = batteryPrefabs[i];
                }
            } else {
                GUI.DrawTexture(buttonRect, batteryInformations[i].unavailableIcon);
            }
        }
    }
}
