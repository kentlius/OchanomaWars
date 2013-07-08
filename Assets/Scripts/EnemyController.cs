using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

    /* 敵の総数 */
    public static int enemyCount = 0;

    /* 道 */
    public Transform[] roadPoints;
    int currentPointNumber = 0;
    /* 移動に使うキャラクターコントローラー */
    public CharacterController moveController;

    /* HP */
    public int hp = 30;
    /* 攻撃力 */
    public int power = 10;
    /* 速さ */
    public float speed = 10f;
    Vector3 movement = Vector3.forward;

    // Use this for initialization
    void Start () {
        /* 敵の目的地を決める */
        UpdateMovement();
        /* 敵の数を増やす */
        enemyCount++;
    }

    // Update is called once per frame
    void Update () {
        /* 次の目的地があれば */
        if (currentPointNumber < roadPoints.Length) {
            /* 次の目的地に向かって動く */
            moveController.SimpleMove(movement * Time.deltaTime);

            /* 目的地との距離を求める */
            float dist = Vector3.Distance(transform.position,
                                          roadPoints[currentPointNumber].position);
            /* 距離が2m未満だったら */
            if (dist < 2) {
                /* 目的地を次のものにする */
                currentPointNumber++;
                /* 敵を目的地に向ける */
                UpdateMovement();
            }
        }

        /* HPがなければ */
        if (hp <= 0) {
            GameObject.Destroy(this.gameObject);
        }
    }

    /* この敵が破壊されたら敵の数を減らす */
    void OnDestroy () {
        enemyCount--;
    }

    /* 敵を目的地に向かって進める関数 */
    void UpdateMovement () {
        if (currentPointNumber >= roadPoints.Length)
            return;
        transform.LookAt(roadPoints[currentPointNumber]);
        movement = transform.forward.normalized * speed;
    }

    /* 敵から攻撃を受けたとき */
    public void OnAttack (BatteryController attacker) {
        hp -= attacker.power;
    }
}
