using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3DownViewforE : MonoBehaviour
{
    public Rigidbody rb;
    public float changeMass;
    public float startMass;
    public Vector3 changeScale;
    public Vector3 startScale;
    public float skill3Time;
    public GameObject player;

    //BallController scriptから値を取得する
    public BallController ballControllerScript;
    public float defaultPower;
    public float changePower;

    public GameObject skill3Object;
    public ParticleSystem skill3Explosion;
    public GameObject enemy;
    public DvenemyScript enemyScript;
    // Start is called before the first frame update


    void Start()
    {
        ballControllerScript = GetComponent<BallController>();
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        startMass = rb.mass;
        startScale = this.gameObject.transform.localScale;
        defaultPower = ballControllerScript.playerDefaultSpeed;
        skill3Explosion = skill3Object.GetComponent<ParticleSystem>();


        enemy = GameObject.Find("Enemy");
        enemyScript = enemy.GetComponent<DvenemyScript>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("Skill3Activate");

        }
    }
    IEnumerator Skill3Activate()
    {
        ballControllerScript.playerDefaultSpeed = changePower;
        this.transform.localScale = changeScale;
        rb.mass = changeMass;
        skill3Explosion.Play();
        enemyScript.Skill3Discharge(player.transform.position);
        yield return new WaitForSeconds(skill3Time);
        this.transform.localScale = startScale;
        rb.mass = 2.2f;
        ballControllerScript.playerDefaultSpeed = defaultPower;


    }
}
