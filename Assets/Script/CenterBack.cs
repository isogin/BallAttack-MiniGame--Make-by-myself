using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterBack : MonoBehaviour
{
    public GameObject powerPoint;
    Rigidbody rb;
    public bool airPosition;
    public float power;
    public float correctiron;  //英語で補正の意味
    public bool timeLimit;
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(airPosition == false)
        {
            timeLimit = true;
            StartCoroutine("Correction");
            if (timeLimit == true)
            {
                rb.AddForce((powerPoint.transform.position - gameObject.transform.position) * correctiron);
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            rb.velocity = Vector3.zero;
            rb.AddForce((powerPoint.transform.position - gameObject.transform.position) * power, ForceMode.Impulse);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        airPosition = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        airPosition = false;
    }
    
    IEnumerator Correction()
    {
        yield return new WaitForSeconds(0.3f);
        timeLimit = false;
    }



}

