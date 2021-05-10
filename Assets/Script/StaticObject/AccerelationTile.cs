using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccerelationTile : MonoBehaviour
{
    public Rigidbody playerRB;

    public Rigidbody enemyRB;

    public float massChangeTime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBall")
        {
            //見た目を変える

            //速さをアップ！！
            playerRB.velocity *= 1.5f;
            StartCoroutine("PlayerTouch");
        }

        if(other.gameObject.tag == "enemyBall")
        {
            //見た目を変える

            //速さをアップ！！
            enemyRB.velocity *= 1.5f;
            StartCoroutine("EnemyTouch");
        }

    }
    IEnumerator PlayrTouch()
    {
        playerRB.mass *= 1.5f;
        yield return new WaitForSeconds(massChangeTime);
        playerRB.mass = playerRB.mass * 2 / 3;
    }

    IEnumerator EnemyTouch()
    {
        enemyRB.mass *= 1.5f;
        yield return new WaitForSeconds(massChangeTime);
        enemyRB.mass = enemyRB.mass * 2 / 3;
    }
    
}
