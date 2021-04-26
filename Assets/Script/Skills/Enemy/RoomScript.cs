using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
public class RoomScript : MonoBehaviour
{
    GameObject enemy;
    GameObject player;

    public GameObject particleObject;
    

    Rigidbody playerRB;


    BallController playerScript;


    public float normalIndex;

    public float lifeTime;
    float elapsedTime;

    bool wherePlayer;
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        player = GameObject.Find("Player");
        this.gameObject.transform.parent = enemy.gameObject.transform;

        playerRB = player.GetComponent<Rigidbody>();

        playerScript = player.GetComponent<BallController>();

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if(elapsedTime >= lifeTime)
        {
            Destroy();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBall")
        {
            TimeDelay();

            wherePlayer = true;
            Instantiate(particleObject, player.transform.position, Quaternion.identity);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        
        if (other.gameObject.tag == "PlayerBall")
        {
            TimeNormal();
            wherePlayer = false;
        }
            
    }


     private void TimeDelay()
    {
        playerRB.velocity *= 0.5f;


        playerRB.mass -= 0.5f;
         playerScript.playerDefaultSpeed = playerScript.playerDefaultSpeed * 0.5f;

    }

    private void TimeNormal()
    {
        playerRB.mass += 0.5f;
        playerRB.velocity *= normalIndex;
        playerScript.playerDefaultSpeed = playerScript.playerDefaultSpeed * 2f;

    }

    void Destroy()
    {
        if (wherePlayer)
        {
            TimeNormal();
        }
        Destroy(this.gameObject);

    }
}
