using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleScripts : MonoBehaviour
{
    public GameObject impactEffect;

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "enemyBall")
        {
            //衝突エフェクトのパーティクルを発生
            Instantiate(impactEffect, transform.position, transform.rotation);
        }
    }
}
