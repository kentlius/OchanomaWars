using UnityEngine;
using System.Collections;

public class Spawn : MonoBehaviour {

    /* 敵を入れておくゲームオブジェクト */
    public Transform enemyRoot;
    /* 道 */
    public Transform[] roadPoints;

    /* ウェーブ（ステージ）を定義するためのクラス */
    [System.Serializable]
    public class Wave {
        public GameObject[] enemies;
    };
    public Wave[] waves;
    /* 現在のウェーブ番号 */
    public int waveIndex = 0;
    /* 次に出すウェーブの中の敵の番号 */
    int enemyIndex = 0;

    /* 敵が出てくる時間 */
    public float spawnInterval = 5f;
    float lastSpawnTime = 0f;

    /* リザルト画面を表示するオブジェクト */
    public ResultScreen resultScreen;

    /* マナを管理するオブジェクト */
    public BatteryPlacer batteryPlacer;

    // Update is called once per frame
    void Update () {
        /* 時間になったら */
        if (lastSpawnTime + spawnInterval < Time.time ) {
            /* 敵が全て出ていなければ敵を出す */
            if (enemyIndex < waves[waveIndex].enemies.Length) {
                EnemyController newEnemy = (Instantiate(waves[waveIndex].enemies[enemyIndex]
                                                        , this.transform.position
                                                        , Quaternion.identity) as
                                            GameObject).GetComponent<EnemyController>();
                newEnemy.transform.parent = enemyRoot;
                newEnemy.roadPoints = this.roadPoints;
                newEnemy.batteryPlacer = this.batteryPlacer;

                enemyIndex++;
                /* すでにすべての敵が出てきていてその敵が全滅していれば次のウェーブに移行する */
            } else if (EnemyController.enemyCount == 0) {
                enemyIndex = 0;
                waveIndex++;
                /* 次のウェーブがあればリザルト画面を表示する */
                if (waveIndex < waves.Length) {
                    ShowResult();
                    /* 次のウェーブがなければゲームクリア画面を表示する */
                } else {
                    Application.LoadLevel("GameClearScreen");
                }
            }
            lastSpawnTime = Time.time;
        }
    }

    /* 完了したウェーブのリザルト画面を表示 */
    void ShowResult () {
        print("Show Result");
        resultScreen.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
}
