using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerationSkill1forE : MonoBehaviour
{
    Rigidbody rb;

    public float acceleratePower;

    TrailRenderer tr;
    GameObject player;
    bool skillOn = false;

    public float firstMass;
    public float traceIndex;

    public float timeOut;
    private float timeElapsed;

    public float skillTime;
    bool skillFinish = true;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = this.gameObject.GetComponent<Rigidbody>();
        tr = this.gameObject.GetComponent<TrailRenderer>();

        firstMass = rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;

        Vector3 traceVector = (player.transform.position - this.gameObject.transform.position).normalized;

        if (timeElapsed >= timeOut && skillFinish)
        {
            timeElapsed = 0f;
            rb.AddForce(traceVector * acceleratePower, ForceMode.Impulse);
            tr.enabled = true;
            SkillOn();
            rb.mass = firstMass * 1.5f;
            Invoke("StopAccelerateAndTrail", skillTime);
            Invoke("SkillFinish", skillTime);
            skillFinish = false;

        }
        if(skillOn == true)
        {
            rb.AddForce(traceVector * traceIndex);

        }

    }
    void SkillOn()
    {
        skillOn = true;
    }
    void StopAccelerateAndTrail()
    {
        rb.velocity *=  0.5f;
        if (skillOn == true)
        {
            rb.mass = firstMass;
            tr.enabled = false;
            skillOn = false;
        }
    }
    void TouchObject()
    {
        if (skillOn == true)
        {
            rb.mass = firstMass;
            tr.enabled = false;
            skillOn = false;
        }
    }
    void SkillFinish()
    {
        skillFinish = true;
        timeElapsed = 0;
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBall" && skillOn == true)
        {
            TouchObject();
        }
    }
}

