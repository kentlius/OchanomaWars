using UnityEngine;
using System.Collections;

public class StatusGUI : MonoBehaviour {

    /* HPとマナの参照 */
    public Tower tower;
    public BatteryPlacer batteryPlacer;

    /* GUIを表示する */
    void OnGUI () {
        GUI.BeginGroup(new Rect(10, 10, 100, 80));
        GUILayout.Label("HP: " + tower.hp.ToString());
        GUILayout.Label("Mana: " + batteryPlacer.mana.ToString());
        GUI.EndGroup();
    }
}
