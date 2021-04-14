using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3forE : MonoBehaviour
{
    public Rigidbody rb;
    public float changeMass;
    public float startMass;
    public Vector3 changeScale;
    public Vector3 startScale;
    public float skill3Time;
    public GameObject player;

    //BallController scriptから値を取得する
    public TpsPlayerMover ballControllerScript;
    public float defaultPower;
    public float changePower;
    public ParticleSystem skill3Explosion;
    GameObject enemy;
    enemyScripts enemyScript;
    // Start is called before the first frame update


    void Start()
    {
        ballControllerScript = GetComponent<TpsPlayerMover>();
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        startMass = rb.mass;
        startScale = this.gameObject.transform.localScale;
        defaultPower = ballControllerScript.playerDefaultSpeed;
        skill3Explosion = GetComponentInChildren<ParticleSystem>();


        enemy = GameObject.Find("Enemy");
        enemyScript = enemy.GetComponent<enemyScripts>();
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
        rb.mass = startMass;
        ballControllerScript.playerDefaultSpeed = defaultPower;

        
    }
}
