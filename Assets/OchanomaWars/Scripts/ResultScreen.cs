using UnityEngine;
using System.Collections;

public class ResultScreen : MonoBehaviour {

    /* 敵を管理するオブジェクト */
    public Spawn enemySpawn;
    /* 砲台を置くGUI */
    public BatteryPlaceGUI batterySpawn;
    /* この画面の大きさ */
    public Vector2 windowSize = new Vector2(800, 600);
    Rect windowRect;

    /* このコンポーネントが起動されたときに砲台を置くGUIを無効にする */
    void OnEnable () {
        batterySpawn.gameObject.SetActive(false);
    }

    /* GUIを表示する */
    void OnGUI () {
        /* ウィンドウの大きさを決める */
        windowRect =
            new Rect(Screen.width / 2 - windowSize.x / 2,
                     Screen.height / 2 - windowSize.y / 2,
                     windowSize.x, windowSize.y);
        /* ウィンドウを表示する */
        GUI.Box(windowRect, "Success!!");

        /* 次のウェーブに行くボタンを表示する */
        if(GUI.Button(
                    new Rect(windowRect.xMax - 260, windowRect.yMax - 80, 240, 60),
                    "Next Wave")) {
            enemySpawn.gameObject.SetActive(true);
            batterySpawn.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
