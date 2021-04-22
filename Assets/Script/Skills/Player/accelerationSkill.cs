using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerationSkill : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 latestPos;
    public float acceleratePower;
    public Vector3 diff;
    TrailRenderer tr;
    GameObject enemy;
    bool skillOn = false;

    SkillController skillcontroller;
    public GameObject skillcontrollObject;

    public float firstMass;
    public float traceIndex;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        rb = gameObject.GetComponent<Rigidbody>();
        tr = this.gameObject.GetComponent<TrailRenderer>();

        skillcontroller = skillcontrollObject.GetComponent<SkillController>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 traceVector = enemy.transform.position - gameObject.transform.position;
        diff = (gameObject.transform.position - latestPos).normalized;
        latestPos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space) || skillcontroller.skillOnPossible)
        {
            rb.AddForce(diff * acceleratePower, ForceMode.Impulse);
            tr.enabled = true;
            SkillOn();
            rb.mass = firstMass * 1.5f;
            Invoke("StopAccelerate", 0.8f);
            Invoke("StopTrail", 0.8f);

            skillcontroller.SkillUsed();

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
    void StopAccelerate()
    {
        rb.velocity = rb.velocity * 0.5f;

    }
    void StopTrail()
    {
        
        if (skillOn == true)
        {
            rb.mass = firstMass;
            tr.enabled = false;
            skillOn = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemyBall" && skillOn == true)
        {
            StopTrail();
        }
    }
}

