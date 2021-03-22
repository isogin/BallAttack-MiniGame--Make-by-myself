using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UDBounceWall : MonoBehaviour
{
    
        public GameObject player;
    public GameObject enemy;

    Rigidbody enemyRb;
    Rigidbody playerRb;
    public float upForce;
    Vector3 forceE;
    Vector3 forceP;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        enemyRb = enemy.GetComponent<Rigidbody>();
        playerRb = player.GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter(Collision collision)
    {
       
    }
}

