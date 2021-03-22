using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWall : MonoBehaviour
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
        if (collision.gameObject.tag == "enemyBall")
        {

            if(this.gameObject.transform.position.x < enemy.transform.position.x)
            {
                forceE = new Vector3(10, upForce, 0);
            }
            else
            {
                forceE = new Vector3(-10, upForce, 0);
            }


            enemyRb.AddForce(forceE, ForceMode.Impulse);
        }
        if (collision.gameObject.tag == "PlayerBall")
        {
            if (this.gameObject.transform.position.x < player.transform.position.x)
            {
                forceP = new Vector3(10, upForce, 0);
            }
            else
            {
                forceP = new Vector3(-10, upForce, 0);
            }


            playerRb.AddForce(forceP, ForceMode.Impulse);
        }
    }
}