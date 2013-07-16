using UnityEngine;
using System.Collections;

public class BatteryPlacer : MonoBehaviour {

    public Transform batteryRoot;
    public GameObject batteryPrefab;

    public Light cursor;
    Transform cursorTransform;

    public LayerMask floorLayer = 1 << 11;

    void Start () {
        cursorTransform = cursor.GetComponent<Transform>();
    }

    void Update () {
        if (batteryPrefab == null)
            return;

        /* ドラッグ */
        if (Input.GetMouseButton(0)) {
            PlaceCursor();
        }
        if (Input.GetMouseButtonUp(0) && cursor.color == Color.green) {
            PlaceBatteryToCursorPosition();
        }
    }

    void PlaceCursor () {
        RaycastHit hitPlace = new RaycastHit();
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast (cameraRay.origin, cameraRay.direction, out hitPlace,
                             Mathf.Infinity)) {
            /* カーソルを配置 */
            cursorTransform.position = hitPlace.point + Vector3.up * 100;
            /* カーソルが砲台を置けない場所を指していたら */
            if (((1 << hitPlace.collider.gameObject.layer) & floorLayer) == 0) {
                cursor.color = Color.red;
            } else {
                cursor.color = Color.green;
            }
        }
    }

    void PlaceBatteryToCursorPosition () {
        Transform batteryTransform = (GameObject.Instantiate(batteryPrefab) as
                                      GameObject).GetComponent<Transform>();
        batteryTransform.parent = batteryRoot;
        batteryTransform.position = cursorTransform.position + Vector3.down * 100;
        batteryPrefab = null;
    }
}
