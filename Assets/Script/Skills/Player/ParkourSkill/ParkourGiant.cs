using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourGiant : MonoBehaviour
{
    public Rigidbody rb;

    public Vector3 changeScale;
    public Vector3 startScale;
    public float skill3Time;
    public GameObject player;

    public DWGDestroyer destroyer;
    public TpsPlayerMover playerScript;
    public float radiusIndex;
    public float forceIndex;
    public float changeSpeed;
    public float changeMass;
    public GameObject skill3Object;
    public ParticleSystem skill3Explosion;

    float defaultPower;
    float defaultMass;
    void Start()
    {
        player = GameObject.Find("Player");
        rb = GetComponent<Rigidbody>();
        startScale = this.gameObject.transform.localScale;

        skill3Explosion = skill3Object.GetComponent<ParticleSystem>();
        playerScript = player.GetComponent<TpsPlayerMover>();
        destroyer = player.GetComponent<DWGDestroyer>();

        defaultPower = playerScript.playerDefaultSpeed;
        defaultMass = rb.mass;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("Skill3Activate");
        }
    }
    IEnumerator Skill3Activate()
    {
        skill3Explosion.Play();
        this.transform.localScale = changeScale;
        playerScript.playerDefaultSpeed = changeSpeed;
        rb.mass = changeMass;
        destroyer.radius = radiusIndex;
        destroyer.force = forceIndex;

        yield return new WaitForSeconds(skill3Time);

        this.transform.localScale = startScale;
        destroyer.radius = 0;
        destroyer.force = 0;

        playerScript.playerDefaultSpeed = defaultPower;
        rb.mass = defaultMass;

    }
}
