using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCrash : MonoBehaviour
{
    Rigidbody rb;
    public float speed;
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(0, speed, 0), ForceMode.Impulse);
    }

    // Update is called once per frame

}
