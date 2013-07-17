using UnityEngine;
using System.Collections;

public class BatteryController : MonoBehaviour {

    /* この砲台のコスト */
    public int cost = 30;

    /* 砲台の攻撃力 */
    public int power = 50;
    /* 現在の攻撃対象 */
    public EnemyController targetEnemy;

    /* この砲台が攻撃をする間隔 */
    public float attackInterval = 0.8f;
    float lastAttackTime = 0f;

    /* この砲台の発射口の場所 */
    public Transform muzzlePosition;
    /* 炎のプレファブ */
    public GameObject activeFirePrefab;
    public GameObject passiveFirePrefab;

    /* 普通のUpdate */
    void Update () {
        if (targetEnemy != null) {
            transform.LookAt(targetEnemy.transform);

            /* 前回攻撃してから時間が立っていたら攻撃する */
            if (lastAttackTime + attackInterval < Time.time) {
                AttackTo(targetEnemy);
                lastAttackTime = Time.time;
            }
        }
    }

    /* 敵が攻撃範囲に入ってきたとき */
    void OnTriggerEnter (Collider teki) {
        /* EnemyController コンポーネントを取り出す */
        targetEnemy =
            teki.gameObject.GetComponent<EnemyController>();
    }

    /* 敵が攻撃範囲から出たてきたとき */
    void OnTriggerExit () {
        targetEnemy = null;
    }

    /* 敵に攻撃する */
    void AttackTo (EnemyController enemy) {
        /* 砲身からの炎 */
        Transform activeFire = (GameObject.Instantiate(activeFirePrefab) as
                                GameObject).GetComponent<Transform>();
        activeFire.parent = muzzlePosition;
        activeFire.localPosition = Vector3.zero;

        /* 敵の炎 */
        Transform passiveFire = (GameObject.Instantiate(passiveFirePrefab) as
                                 GameObject).GetComponent<Transform>();
        passiveFire.parent = enemy.transform;
        passiveFire.localPosition = Vector3.zero;

        enemy.OnAttack(this);
    }
}
