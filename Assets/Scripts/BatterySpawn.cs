using UnityEngine;
using System.Collections;

public class BatterySpawn : MonoBehaviour {

    public GameObject[] batteryPrefabs;
    public BatteryPlacer batteryPlace;

    Vector2 windowSize;
    Rect windowRect;
    Vector2 buttonSize;

    void Strat () {

    }

    void OnGUI () {
        if (batteryPlace.batteryPrefab != null)
            return;

        windowSize = new Vector2(Screen.width - 20, Screen.height * 0.2f);
        windowRect =
            new Rect(10, Screen.height - windowSize.y,
                     windowSize.x, windowSize.y);

        buttonSize = new Vector2(120, 48);

        // Make a background box
        GUI.Box(windowRect, "Units");

        for (int i = 0; i < batteryPrefabs.Length; i++) {
            if(GUI.Button(
                        new Rect(windowRect.xMin + 10 + buttonSize.x * i,
                                 windowRect.yMax - buttonSize.y - 10,
                                 buttonSize.x, buttonSize.y)
                        , batteryPrefabs[i].name)) {
                batteryPlace.batteryPrefab = batteryPrefabs[i];
            }
        }
    }
}
