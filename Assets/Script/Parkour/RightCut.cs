using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCut : MonoBehaviour
{
    public float cutSpeed;
    Rigidbody rb;
    private void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();

        rb.AddForce(new Vector3(0, 0,cutSpeed), ForceMode.Impulse);
    }

}
