using UnityEngine;
using System.Collections;

public class TimeDestroy : MonoBehaviour {

    /* 自動で破壊されるまでの時間 */
    public float destroyTime = 3f;
    float bornTime;

    /* 時間を数え始める */
    void Start () {
        bornTime = Time.time;
    }

    /* 時間が経過したらオブジェクトを破壊する */
    void Update () {
        if (bornTime + destroyTime < Time.time) {
            GameObject.Destroy(gameObject);
        }
    }
}
