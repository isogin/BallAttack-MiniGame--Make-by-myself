using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveObject : MonoBehaviour
{
    Rigidbody rb;
    public GameObject eventCube;
    float speed;
    bool oneUse = true;
    public float minSpeed;
    public float maxSpeed;
    public float movetime;
    bool skillOn;

    float timeElapsed;
    float timeOut = 30;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeOut < timeElapsed)
        {
            Destroy(this.gameObject);
        }
        if(!(eventCube) && oneUse)
        {
            EventOn();
            oneUse = false;
        }

        if(skillOn)
        {

            rb.AddForce(new Vector3(0, 0, speed), ForceMode.Impulse);
            Invoke("ForceStop", 1.5f);
        }

    }

    void EventOn()
    {
        speed = Random.Range(10, 15);

        skillOn = true;
    }
    void ForceStop()
    {
        skillOn = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "enemyBall")
        {
            Destroy(this.gameObject);
        }
    }
}
