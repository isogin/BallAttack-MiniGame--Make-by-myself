using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerserkSkill : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 latestPos;
    public float acceleratePower;
    public Vector3 diff;
    TrailRenderer tr;
    GameObject enemy;
    bool skillOn = false;
    public float skillTime;
    public float traceIndex;
    public float debufTime;
    bool debuf = false;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        rb = gameObject.GetComponent<Rigidbody>();
        tr = this.gameObject.GetComponent<TrailRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 traceVector = enemy.transform.position - gameObject.transform.position;
        diff = (gameObject.transform.position - latestPos).normalized;
        latestPos = gameObject.transform.position;
        if (Input.GetKeyDown(KeyCode.R))
        {
            rb.velocity = diff * acceleratePower;
            tr.enabled = true;
            SkillOn();
            Invoke("StopAccelerate", 0.2f);
            Invoke("StopTrail", skillTime);
        }
        if (skillOn == true)
        {
            rb.AddForce(traceVector * traceIndex);
        }
        if(debuf == true)
        {
            rb.velocity = diff * 0.5f;
        }

    }
    void SkillOn()
    {
        skillOn = true;
    }
    void StopAccelerate()
    {
        StartCoroutine("SkillDebuf");

    }
    void StopTrail()
    {
        tr.enabled = false;
        skillOn = false;
    }
    IEnumerator SkillDebuf()
    {
        debuf = true;
        yield return new WaitForSeconds(debufTime);
        debuf = false;
    }
}
