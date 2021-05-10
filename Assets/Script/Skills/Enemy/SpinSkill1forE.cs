using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpinSkill1forE : MonoBehaviour
{
    GameObject enemy;
    Rigidbody rb;

    public float movePower;
    public float upPower;

    public float changeMass;
    public float defaultMass;


    public float zSpinPower;
    public float ySipnPower;
    public GameObject spinSkillObject;
    public ParticleSystem spinSkill;

    Vector3 right;
    Vector3 left;
    Vector3 down;
    Vector3 up;

    public int percent = 100;
    public bool hit = true;
    IEnumerator routine;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        rb = enemy.GetComponent<Rigidbody>();

        rb.maxAngularVelocity = Mathf.Infinity;
        spinSkill = spinSkillObject.GetComponent<ParticleSystem>();
        defaultMass = rb.mass;

        //常にベクトルの大きさと傾きを一定にする
        right = new Vector3(movePower,upPower,0);
        left = new Vector3(-movePower,upPower,0);
        up = new Vector3(0,upPower,movePower);
        down = new Vector3(0,upPower,-movePower);

        routine = Coroutine();
        StartCoroutine(routine);
    }



    IEnumerator Coroutine()
    {
        yield return new WaitForSeconds(0.1f);
        rb.mass = changeMass;
        yield return new WaitForSeconds(1f);
        rb.mass = defaultMass;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "TopTrigger")
        {
            if(hit)
            {
                Probability();
                StartCoroutine("Coroutine");
                rb.velocity = Vector3.zero;
                rb.AddForce(down, ForceMode.Impulse);
                spinSkill.Play();
                rb.AddTorque(new Vector3(-ySipnPower, 0, 0) * Mathf.PI, ForceMode.VelocityChange);
            }
            
        }
        if (other.gameObject.tag == "DownTrigger")
        {
            if(hit)
            {
                Probability();
                StartCoroutine("Coroutine");
                rb.velocity = Vector3.zero;
                rb.AddForce(up, ForceMode.Impulse);
                spinSkill.Play();
                rb.AddTorque(new Vector3(ySipnPower, 0, 0) * Mathf.PI, ForceMode.VelocityChange);
            }
            
        }
        if (other.gameObject.tag == "RightTrigger")
        {
            if (hit)
            {
                Probability();
                StartCoroutine("Coroutine");
                rb.velocity = Vector3.zero;
                rb.AddForce(left, ForceMode.Impulse);
                spinSkill.Play();
                rb.AddTorque(new Vector3(0, 0, zSpinPower) * Mathf.PI, ForceMode.VelocityChange);
            }
            
        }
        if (other.gameObject.tag == "LeftTrigger")
        {
            if (hit)
            {
                Probability();
                StartCoroutine("Coroutine");
                rb.velocity = Vector3.zero;
                rb.AddForce(right, ForceMode.Impulse);
                spinSkill.Play();
                rb.AddTorque(new Vector3(0, 0, -zSpinPower) * Mathf.PI, ForceMode.VelocityChange);
            }
            
        }
    }

    void Probability()
    {
        percent -= 20;
        int range = Random.Range(0, 100);
        if(range > percent)
        {
            hit = false;
        }
    }
}
