using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourAcceleration : MonoBehaviour
{
    Rigidbody rb;
    private Vector3 latestPos;
    public float acceleratePower;
    Vector3 pushDirection;
    Vector3 diff;
    TrailRenderer tr;
    bool skillOn = false;
    DWGDestroyer wallDestroy;
    public float radius;
    public float power;
    float firstMass;
    public float pushIndex;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        tr = this.gameObject.GetComponent<TrailRenderer>();

        firstMass = rb.mass;
        wallDestroy = this.gameObject.GetComponent<DWGDestroyer>();
    }

    // Update is called once per frame
    void Update()
    {
        diff = (gameObject.transform.position - latestPos).normalized;
        latestPos = gameObject.transform.position;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            wallDestroy.force = power;
            wallDestroy.radius = radius;
            pushDirection = diff;
 
            rb.AddForce(pushDirection * acceleratePower, ForceMode.Impulse);
            tr.enabled = true;
            SkillOn();
            rb.mass = firstMass * 1.5f;
            Invoke("StopAccelerate", 1f);
            Invoke("StopTrail", 1f);

        }


    }
    void SkillOn()
    {
        skillOn = true;
    }
    void StopAccelerate()
    {
        rb.velocity = rb.velocity * 0.5f;
        wallDestroy.force = 0;
        wallDestroy.radius = 0;

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
         if(collision.gameObject.tag == "Destructible" && skillOn)
        {
            StartCoroutine("speedHold");

        }
    }
    IEnumerator speedHold()
    {
        yield return new WaitForSeconds(0.01f);
        rb.AddForce(pushDirection * pushIndex, ForceMode.Impulse);
    }
}
