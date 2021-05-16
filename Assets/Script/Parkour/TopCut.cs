using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopCut : MonoBehaviour
{
    public float cutSpeed;
    public bool cutOrBack = true;
    Rigidbody rb;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
        rb.AddForce(new Vector3(0, cutSpeed,0), ForceMode.Impulse);
    }

    // Update is called once per frame
    void FixedUpdate()
    {


    }

}
