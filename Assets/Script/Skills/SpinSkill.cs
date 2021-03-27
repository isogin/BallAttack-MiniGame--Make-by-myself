using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSkill : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;

    public float movePower;
    public float upPower;

    public float changeMass;
    public float defaultMass;

    bool spinExplosion = false;
    public float zPower;
    public float yPower;
    public GameObject spinSkillObject;
    public ParticleSystem spinSkill;

    Vector3 right;
    Vector3 left;
    Vector3 down;
    Vector3 up;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();

        rb.maxAngularVelocity = Mathf.Infinity;
        spinSkill = spinSkillObject.GetComponent<ParticleSystem>();
        defaultMass = rb.mass;

        //常にベクトルの大きさと傾きを一定にする
        right = new Vector3(movePower,upPower,0);
        left = new Vector3(-movePower,upPower,0);
        up = new Vector3(0,upPower,movePower);
        down = new Vector3(0,upPower,-movePower);


    }

        void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(right, ForceMode.Impulse);
            spinSkill.Play();
            rb.AddTorque(new Vector3(0, 0, -zPower) * Mathf.PI, ForceMode.VelocityChange);
            StartCoroutine("massChange");
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(left, ForceMode.Impulse);
            spinSkill.Play();
            rb.AddTorque(new Vector3(0, 0, zPower) * Mathf.PI, ForceMode.VelocityChange);

            StartCoroutine("massChange");
        }

        if (Input.GetKeyDown(KeyCode.W))
        {

            rb.velocity = Vector3.zero;
            rb.AddForce(up, ForceMode.Impulse);
            spinSkill.Play();
            rb.AddTorque(new Vector3(yPower, 0, 0) * Mathf.PI, ForceMode.VelocityChange);
            StartCoroutine("massChange");
        }



        if (Input.GetKeyDown(KeyCode.S))
        {  
            rb.velocity = Vector3.zero;
            rb.AddForce(down, ForceMode.Impulse);
            spinSkill.Play();
            rb.AddTorque(new Vector3(-yPower, 0 , 0) * Mathf.PI, ForceMode.VelocityChange);
            StartCoroutine("massChange");
        }

    }

    IEnumerator massChange()
    {
        rb.mass = changeMass;
        spinExplosion = true;
        yield return new WaitForSeconds(0.7f);
        rb.mass = defaultMass;
        spinExplosion = false;
    }
}
