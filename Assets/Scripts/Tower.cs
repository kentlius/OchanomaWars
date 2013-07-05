using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    public int hp = 100;

    /* 敵がぶつかってきたとき */
    void OnTriggerEnter (Collider teki) {
        /* EnemyController コンポーネントを取り出す */
        EnemyController enemyController =
            teki.gameObject.GetComponent<EnemyController>();

        /* 塔にダメージを適用する */
        hp -= enemyController.attack;

        /* 敵を消す */
        GameObject.Destroy(enemyController.gameObject);
    }
}
