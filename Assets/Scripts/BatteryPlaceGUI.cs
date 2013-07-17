using UnityEngine;
using System.Collections;

public class BatteryPlaceGUI : MonoBehaviour {

    /* 砲台のプレファブ */
    public GameObject[] batteryPrefabs;
    public BatteryController[] batteryInformations;
    public BatteryPlacer batteryPlacer;

    /* 砲台を選ぶ画面の大きさ */
    Vector2 windowSize;
    Rect windowRect;
    Vector2 buttonSize;

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
        windowSize = new Vector2(Screen.width - 20, Screen.height * 0.2f);
        windowRect =
            new Rect(10, Screen.height - windowSize.y,
                     windowSize.x, windowSize.y);

        /* ボタンの大きさを決める */
        buttonSize = new Vector2(120, 48);

        /* 砲台を選ぶ画面を表示する */
        GUI.Box(windowRect, "Units");

        /* 砲台を選ぶボタンを表示する */
        for (int i = 0; i < batteryPrefabs.Length; i++) {
            if (batteryInformations[i].cost <= batteryPlacer.mana) {
                if(GUI.Button(
                            new Rect(windowRect.xMin + 10 + buttonSize.x * i,
                                     windowRect.yMax - buttonSize.y - 10,
                                     buttonSize.x, buttonSize.y)
                            , batteryPrefabs[i].name)) {
                    batteryPlacer.batteryPrefab = batteryPrefabs[i];
                }
            }
        }
    }
}
