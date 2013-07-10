using UnityEngine;
using System.Collections;

public class BatteryController : MonoBehaviour {

    public int power = 50;
    public EnemyController targetEnemy;

    public float attackInterval = 0.8f;
    float lastAttackTime = 0f;

    public Transform muzzlePosition;
    public GameObject activeFirePrefab;
    public GameObject passiveFirePrefab;

    // Use this for initialization
    void Start () {
    }

    // Update is called once per frame
    void Update () {
        if (targetEnemy != null) {
            transform.LookAt(targetEnemy.transform);

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
        Transform activeFire = (GameObject.Instantiate(activeFirePrefab) as GameObject).GetComponent<Transform>();
        activeFire.parent = muzzlePosition;
        activeFire.localPosition = Vector3.zero;

        /* 敵の炎 */
        Transform passiveFire = (GameObject.Instantiate(passiveFirePrefab) as GameObject).GetComponent<Transform>();
        passiveFire.parent = enemy.transform;
        passiveFire.localPosition = Vector3.zero;

        enemy.OnAttack(this);
    }
}
