using UnityEngine;
using System.Collections;

public class BatteryPlacer : MonoBehaviour {

    /* マナ */
    public int mana = 100;

    /* 砲台を入れておくゲームオブジェクト */
    public Transform batteryRoot;
    /* 砲台のプレファブ */
    public GameObject batteryPrefab;

    /* カーソル */
    public Light cursor;
    /* 床のレイヤー */
    public LayerMask floorLayer = 1 << 11;

    void Update () {
        if (batteryPrefab == null)
            return;

        /* ドロップ操作 */
        if (Input.GetMouseButtonUp(0) && cursor.color == Color.green) {
            PlaceBatteryToCursorPosition();
        }
        /* ドラッグ操作 */
        if (Input.GetMouseButton(0)) {
            cursor.enabled = true;
            PlaceCursor();
        } else {
            cursor.enabled = false;
            cursor.color = Color.red;
        }
    }

    /* カーソルを置く */
    void PlaceCursor () {
        /* カメラからビーム(Ray)を飛ばしてどこをタッチしているのかを調べる */
        RaycastHit hitPlace = new RaycastHit();
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        /* もし、なにかをタッチしていたら */
        if (Physics.Raycast (cameraRay.origin, cameraRay.direction, out hitPlace,
                             Mathf.Infinity)) {
            /* カーソルを配置 */
            cursor.transform.position = hitPlace.point + Vector3.up * 100;
            /* カーソルが砲台を置けない場所を指していたら */
            if (((1 << hitPlace.collider.gameObject.layer) & floorLayer) == 0) {
                /* カーソルを赤く(砲台を置けなく)する */
                cursor.color = Color.red;
            } else {
                /* カーソルを緑に(砲台を置けるように)する */
                cursor.color = Color.green;
            }
        }
    }

    /* カーソルの位置に基づいて砲台を置く */
    void PlaceBatteryToCursorPosition () {
        GameObject battery = (GameObject.Instantiate(batteryPrefab) as GameObject);

        /* 砲台のコストを支払う */
        mana -= battery.GetComponent<BatteryController>().cost;

        /* 砲台を設置する */
        battery.transform.parent = batteryRoot;
        battery.transform.position = cursor.transform.position + Vector3.down * 100;
        batteryPrefab = null;
    }
}
