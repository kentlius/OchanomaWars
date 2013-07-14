using UnityEngine;
using System.Collections;

public class BatteryPlacer : MonoBehaviour {

    public Transform batteryRoot;
    public GameObject batteryPrefab;

    void Update () {
        if (batteryPrefab != null && Input.GetMouseButton(0)) {
            PlaceBattery();
        }
    }

    void PlaceBattery () {
        RaycastHit hit = new RaycastHit();
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast (cameraRay.origin, cameraRay.direction, out hit,
                             Mathf.Infinity)) {
            Transform batteryTransform = (GameObject.Instantiate(batteryPrefab) as
                                          GameObject).GetComponent<Transform>();
            batteryTransform.parent = batteryRoot;
            batteryTransform.position = hit.point;
            batteryPrefab = null;
        }
    }
}
