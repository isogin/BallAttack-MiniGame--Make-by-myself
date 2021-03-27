using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClone : MonoBehaviour
{
    GameObject player;
    bool finishTrace = true;
    Rigidbody rb;
    public float enemySpeed;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        Invoke("TraceFinish", 4f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 trace = (player.transform.position - this.gameObject.transform.position).normalized;
        if(finishTrace)
        {
            rb.AddForce(trace * enemySpeed);
        }
    }
    void TraceFinish()
    {
        finishTrace = false;
    }
}
