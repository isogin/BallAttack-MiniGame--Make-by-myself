using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourSpin : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;

    public float movePower;
    public float upPower;
    public float zSpinPower;
    public float ySipnPower;
    public GameObject spinSkillObject;
    public ParticleSystem spinSkill;

    public float forwardPower;
    Vector3 right;
    Vector3 left;
    Vector3 down;
    Vector3 up;


    IEnumerator routine;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();

        rb.maxAngularVelocity = Mathf.Infinity;
        spinSkill = spinSkillObject.GetComponent<ParticleSystem>();


        //常にベクトルの大きさと傾きを一定にする
        right = new Vector3(movePower, upPower, -forwardPower);
        left = new Vector3(-movePower, upPower, -forwardPower);
        up = new Vector3(0, upPower, movePower);
        down = new Vector3(0, upPower, -movePower);

    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.D))
        {

            rb.velocity = Vector3.zero;
            rb.AddForce(left, ForceMode.Impulse);
            spinSkill.Play();
            rb.AddTorque(new Vector3(0, 0, zSpinPower) * Mathf.PI, ForceMode.VelocityChange);

        }

        if (Input.GetKey(KeyCode.A))
        {

            rb.velocity = Vector3.zero;
            rb.AddForce(right, ForceMode.Impulse);
            spinSkill.Play();
            rb.AddTorque(new Vector3(0, 0, -zSpinPower) * Mathf.PI, ForceMode.VelocityChange);


        }

        if (Input.GetKey(KeyCode.W))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(down, ForceMode.Impulse);
            spinSkill.Play();
            rb.AddTorque(new Vector3(-ySipnPower, 0, 0) * Mathf.PI, ForceMode.VelocityChange);

        }



        if (Input.GetKey(KeyCode.S))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(up, ForceMode.Impulse);
            spinSkill.Play();
            rb.AddTorque(new Vector3(ySipnPower, 0,0) * Mathf.PI, ForceMode.VelocityChange);

        }
    }
}
