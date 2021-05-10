using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill3DownView1forE : MonoBehaviour
{
    public Rigidbody rb;
    public float changeMass;
    public float startMass;
    public Vector3 changeScale;
    public Vector3 startScale;
    public float skill3Time;
    public GameObject player;

    BallController playerScript;

    public float defaultPower;
    public float changePower;

    public GameObject skill3Object;
    public ParticleSystem skill3Explosion;
    public DvenemyScript enemyScript;
    // Start is called before the first frame update

    public float timeOut;
    private float timeElapsed;

    public float explosionIndex;
    bool skillFinish = true;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = this.gameObject.GetComponent<Rigidbody>();
        startMass = rb.mass;
        startScale = this.gameObject.transform.localScale;

        skill3Explosion = skill3Object.GetComponent<ParticleSystem>();

        playerScript = player.GetComponent<BallController>();
        defaultPower = enemyScript.enemySpeed;
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > timeOut && skillFinish)
        {
            skillFinish = false;
            StartCoroutine("Skill3Activate");
            Invoke("SkillFinish", skill3Time);
        }
    }
    IEnumerator Skill3Activate()
    {
        Debug.Log("hit");
        enemyScript.enemySpeed = changePower;
        transform.localScale = changeScale;
        rb.mass = changeMass;
        skill3Explosion.Play();
        playerScript.Explosion(transform.position, explosionIndex);
        yield return new WaitForSeconds(skill3Time);
        this.transform.localScale = startScale;
        rb.mass = 2.2f;
        enemyScript.enemySpeed = defaultPower;

    }

    void SkillFinish()
    {
        timeElapsed = 0;

        skillFinish = true;
    }
}
