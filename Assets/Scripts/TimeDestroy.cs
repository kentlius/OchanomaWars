using UnityEngine;
using System.Collections;

public class TimeDestroy : MonoBehaviour {

    public float deathTime = 3f;
    float bornTime;

    // Use this for initialization
    void Start () {
        bornTime = Time.time;
    }

    // Update is called once per frame
    void Update () {
        if (bornTime + deathTime < Time.time) {
            GameObject.Destroy(gameObject);
        }
    }
}
