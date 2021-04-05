using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    public float n;
    ParticleSystem.EmissionModule emmision;
    GameObject player;
    BallController playerScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<BallController>();
        StartCoroutine("ParticlesDestroy");
        emmision = GetComponent<ParticleSystem>().emission;
    }

    // Update is called once per frame
    void Update()
    {
        emmision.SetBurst(0, new ParticleSystem.Burst(0, playerScript.collisionImpact * n));
    }
    IEnumerator ParticlesDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
     
}
