using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZeroGravity : MonoBehaviour
{
    [SerializeField] private Vector3 localGravity;
    private Rigidbody rBody;

    public float changeAltitudeSpan;
    public float min;
    public float max;
    Vector3 flowObject;
    // Use this for initialization
    private void Start()
    {
        rBody = this.GetComponent<Rigidbody>();
        rBody.useGravity = false; //最初にrigidBodyの重力を使わなくする
    }

    private void FixedUpdate()
    {
        StartCoroutine("DecideFlow");
        SetLocalGravity(); //重力をAddForceでかけるメソッドを呼ぶ。FixedUpdateが好ましい。

        rBody.AddForce(flowObject);
    }

    private void SetLocalGravity()
    {
        rBody.AddForce(localGravity, ForceMode.Acceleration);
    }

     IEnumerator DecideFlow()
    {
        flowObject = new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));

        yield return null;
        StartCoroutine("DecideFlow");
    }
    
}
