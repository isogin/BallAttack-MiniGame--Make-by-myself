using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrongEnemyScript : MonoBehaviour
{
    public GameObject player;
    public BallController playerScript;
    public bool touchGround;
    public bool awaynow = false;
    public GameObject destination;
    public bool destinationSet = false;
    public Rigidbody rb;
    public float explosionPower;
    public float radius;
    public bool setRunPosition = false;
    public Vector3 playerSetPosition;
    public float enemySpeed;

    public GameObject enemyDestinationalArea;
    GameObject enemyDestinationalAreaClone;


    Vector3 SEnemyAttack;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<BallController>();
    }

    // Update is called once p frame
    void Update()
    {

        //enemyが地面にいて、攻撃状態のとき
        if (touchGround == true && awaynow == false)
        {
            //攻撃位置が指定されていない状態で、プレイヤーが地面についているとき
            if (setRunPosition == false && playerScript.airPosition)
            {
                SEnemyAttack = (player.transform.position - this.gameObject.transform.position).normalized;

                rb.AddForce(SEnemyAttack * enemySpeed);

            }
            //エネミーからプレイヤーへの方向を取得


            //enemyが攻撃位置に着いたとき
            if (this.gameObject.transform.position.x == playerSetPosition.x && this.gameObject.transform.position.z == playerSetPosition.z)
            {
                //逃げる状態にして、逃げ位置を指定する
                awaynow = true;
                destinationSet = true;
            }
        }
        //enemyが地面にいて、逃げる状態であるとき
        if (awaynow == true && touchGround == true)
        {
            if (destinationSet == true)
            {

                destination.transform.position = new Vector3(Random.Range(-2.0f, 2.0f), this.gameObject.transform.position.y, Random.Range(-2.0f, 2.0f));
                enemyDestinationalAreaClone = Instantiate(enemyDestinationalArea, destination.transform.position, this.gameObject.transform.rotation) as GameObject;
                destinationSet = false;

            }
            //逃げる位置へ力を加える
            Vector3 runAwayPosition = destination.transform.position - this.gameObject.transform.position;
            Vector3 unityRunAwayPosition = runAwayPosition.normalized;
            rb.AddForce(unityRunAwayPosition * enemySpeed);

            //enemyが逃げる位置に着いたとき
            if (this.gameObject.transform.position.x == destination.transform.position.x && this.gameObject.transform.position.z == destination.transform.position.z)
            {
                awaynow = false;
                setRunPosition = false;

            }

        }

    }
    private void OnCollisionStay(Collision collision)
    {
        touchGround = true;
    }
    private void OnCollisionEmter(Collision collision)
    {
        touchGround = false;
        if (collision.gameObject.tag == "enemyBall")
        {
            setRunPosition = true;
            awaynow = true;
            destinationSet = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnemyDestinationArea")
        {

            Destroy(enemyDestinationalAreaClone);
            awaynow = false;
            setRunPosition = false;

        }

    }
    public void Skill3Discharge(Vector3 explosionPOs)
    {
        rb.AddExplosionForce(explosionPower, explosionPOs, radius, 3.0F);
    }

    public void Skill1Discharge(Vector3 explosionPOs)
    {
        rb.AddExplosionForce(explosionPower * 0.6f, explosionPOs, radius, 2.0F);
    }
}

