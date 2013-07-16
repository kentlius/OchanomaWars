using UnityEngine;
using System.Collections;

public class ResultScreen : MonoBehaviour {

    public Spawn enemySpawn;
    public BatteryPlaceGUI batterySpawn;
    public Vector2 windowSize = new Vector2(800, 600);
    Rect windowRect;

    void OnEnable () {
        batterySpawn.gameObject.SetActive(false);
    }

    void OnGUI () {
        windowRect =
            new Rect(Screen.width / 2 - windowSize.x / 2,
                     Screen.height / 2 - windowSize.y / 2,
                     windowSize.x, windowSize.y);
        // Make a background box
        GUI.Box(windowRect, "Success!!");

        // Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
        if(GUI.Button(
                    new Rect(windowRect.xMax - 260, windowRect.yMax - 80, 240, 60),
                    "Next Wave")) {
            enemySpawn.gameObject.SetActive(true);
            batterySpawn.gameObject.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}
