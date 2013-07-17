using UnityEngine;
using System.Collections;

public class Tower : MonoBehaviour {

    /* この塔の耐久力(HP) */
    public int hp = 100;

    /* 敵がぶつかってきたとき */
    void OnTriggerEnter (Collider teki) {
        /* EnemyController コンポーネントを取り出す */
        EnemyController enemyController =
            teki.gameObject.GetComponent<EnemyController>();

        /* 塔にダメージを適用する */
        hp -= enemyController.power;

        /* もし、HPが0未満だったらゲームオーバー画面を表示する */
        if (hp < 0)
            Application.LoadLevel("GameOverScreen");

        /* 敵を消す */
        GameObject.Destroy(enemyController.gameObject);
    }
}
