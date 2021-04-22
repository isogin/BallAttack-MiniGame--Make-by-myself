using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomPlayer : MonoBehaviour
{
    GameObject player;
    GameObject enemy;

    Rigidbody enemyRB;

    public GameObject particleObject;
    DvenemyScript enemyScript;

    public float skillTime;
    public float elapsedTime;

    bool wherePlayer;
    public float normalIndex;
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        player = GameObject.Find("Player");

        this.gameObject.transform.parent = player.gameObject.transform;

        enemyRB = enemy.GetComponent<Rigidbody>();

        enemyScript = enemy.GetComponent<DvenemyScript>();

        Invoke("Destroy", skillTime);
    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime = Time.deltaTime;

        if(elapsedTime >= skillTime)
        {
            Destroy();
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "enemyBall")
        {
            TimeDelay();

            wherePlayer = true;
            Instantiate(particleObject, enemy.transform.position, Quaternion.identity);

            //デバフを付け加える
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "enemyBall")
        {
            wherePlayer = false;
            TimeNormal();

        }

    }


    private void TimeDelay()
    {
        enemyRB.velocity *= 0.3f;

        enemyScript.enemySpeed = enemyScript.enemySpeed * 0.5f;

        enemyRB.mass -= 0.5f;

    }
    
    private void TimeNormal()
    {
        enemyRB.velocity *= normalIndex;
        enemyScript.enemySpeed = enemyScript.enemySpeed * 2f;

        enemyRB.mass += 0.8f;
    }

    void Destroy()
    {
        if(wherePlayer)
        {
            TimeNormal();
        }
        Destroy(this.gameObject);
    }
}
