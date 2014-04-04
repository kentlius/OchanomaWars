using UnityEngine;
using System.Collections;

public class EnemyController : MonoBehaviour {

	/* 敵の総数 */
	public static int enemyCount = 0;

	/* 道 */
	public Transform[] roadPoints;
	int currentPointIndex = 0;
	/* 移動に使うキャラクターコントローラー */
	public NavMeshAgent navmeshAgent;
	/* マナを管理するオブジェクト */
	[HideInInspector]
	public BatteryPlacer batteryPlacer;

	/* HP */
	public int hp = 30;
	/* 攻撃力 */
	public int power = 10;
	/* 倒したときのボーナスマナ */
	public int bonusMana = 10;

	/* この敵の初め */
	void Start () {
		/* 敵の目的地を決める */
		UpdateMovement();
		/* 敵の数を増やす */
		enemyCount++;
	}

	/* Updateの後に呼ばれる関数 */
	void LateUpdate () {
		/* HPがなければ */
		if (hp <= 0) {
			/* この敵を破壊する */
			GameObject.Destroy(gameObject);
			/* ボーナスマナを追加 */
			batteryPlacer.mana += bonusMana;
			return;
		}

		/* 次の目的地があれば */
		if (currentPointIndex < roadPoints.Length) {

			/* 距離が2m未満だったら */
			if (navmeshAgent.remainingDistance <= navmeshAgent.stoppingDistance) {
				/* 目的地を次のものにする */
				currentPointIndex++;
				/* 敵を目的地に向ける */
				UpdateMovement();
			}
		}
	}

	/* この敵が破壊されたら敵の数を減らす */
	void OnDestroy () {
		enemyCount--;
	}

	/* 敵を目的地に向かって進める関数 */
	void UpdateMovement () {
		if (currentPointIndex >= roadPoints.Length) {
			navmeshAgent.enabled = false;
			return;
		}
//        transform.LookAt(roadPoints[currentPointIndex]);
		navmeshAgent.SetDestination(roadPoints[currentPointIndex].position);
		navmeshAgent.acceleration = navmeshAgent.speed;
	}

	/* 敵から攻撃を受けたとき */
	public void OnAttack (BatteryController attacker) {
		hp -= attacker.power;
	}
}
