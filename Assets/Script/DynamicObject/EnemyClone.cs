using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyClone : MonoBehaviour
{
    GameObject player;
    bool finishTrace = true;
    Rigidbody rb;
    public float enemySpeed;

    public float lifeTime;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        Invoke("TraceFinish", lifeTime * 2 / 3);
        Invoke("Destroy", lifeTime);
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
    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}
