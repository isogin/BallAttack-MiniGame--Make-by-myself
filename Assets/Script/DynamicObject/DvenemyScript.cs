using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DvenemyScript : MonoBehaviour
{
    public GameObject player;
    public BallController playerScript;
    public bool touchGround;
    bool awaynow = false;
    public GameObject destination;
    bool destinationSet = false;
    public Rigidbody rb;
    public float explosionPower;
    public float radius;
    public bool setRunPosition = false;
    public Vector3 playerSetPosition;
    public float enemySpeed;

    //敵が移動する位置
    public GameObject enemyDestinationalArea;
    GameObject enemyDestinationalAreaClone;
    public GameObject enemyAttackArea;
    GameObject enemyAttackAreaClone;

    //速度制限
    public float LimitSpeed;
    private float timeElapsed;
    // 追尾性能
    public float traceUpdateTime;
    //衝突の大きさ
    float collisionImpact;

    float halfSpeed;
    float firstSpeed;

    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<BallController>();

        firstSpeed = enemySpeed;
        halfSpeed = enemySpeed * 0.5f;
    }

    // Update is called once p frame
    void FixedUpdate()
    {
        if(collisionImpact > playerScript.collisionImpactLimit)
        {
            enemySpeed = halfSpeed;
            Invoke("NormalSpeed", playerScript.halfPowerTime);
        }
        //enemyが地面にいて、攻撃状態のとき
        if (touchGround == true && awaynow == false)
        {
            //プレイヤーの位置によって攻撃エリアの大きさをかえる
            
            timeElapsed += Time.deltaTime;
            //攻撃位置が指定されていない状態で、プレイヤーが地面についているとき
            if (setRunPosition == false && playerScript.airPosition)
            {
                SetRunPosition();

            }
            

            //攻撃位置を更新する(追尾性能)
            if (timeElapsed >= traceUpdateTime && enemyAttackAreaClone)
            {
                enemyAttackAreaClone.transform.position = player.transform.position;
            }
            //プレイヤーの位置へ力を加える
            Vector3 enemyAttack = playerSetPosition - this.gameObject.transform.position;
            Vector3 unityEnemyAttack = enemyAttack.normalized;

            //enemyを攻撃位置に移動させる   速度制限追加
            if (rb.velocity.magnitude < LimitSpeed)
            {

                rb.AddForce(unityEnemyAttack * enemySpeed);
            }
            //攻撃位置  = enemyAttackAreaCloneにする
            if (enemyAttackAreaClone)
            {
                playerSetPosition = enemyAttackAreaClone.transform.position;
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
            Vector3 centerForce = new Vector3(0, 0, 0) - this.gameObject.transform.position;
            Vector3 fusionVector = (runAwayPosition + centerForce) / 2;
            if (rb.velocity.magnitude < LimitSpeed)
            {
                rb.AddForce(fusionVector * enemySpeed * 0.3f);
            }


        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBall")
        {
            collisionImpact = collision.impulse.magnitude;

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        touchGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        touchGround = false;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "EnemyDestinationArea")
        {

            Destroy(enemyDestinationalAreaClone);
            awaynow = false;
            setRunPosition = false;

        }
        if (other.gameObject.tag == "EnemyAttackArea")

        {
            
            awaynow = true;
            destinationSet = true;
            Destroy(enemyAttackAreaClone);
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

    public void Skill4Discharge(Vector3 explosionPOs)
    {
        rb.AddExplosionForce(explosionPower * 0.2f, explosionPOs, radius, 2.0F);
    }

    public void SetRunPosition()
    {
        
        //攻撃位置指定完了！！
        setRunPosition = true;
        enemyAttackAreaClone = Instantiate(enemyAttackArea, player.transform.position, this.gameObject.transform.rotation) as GameObject;
        
    }

    void NormalSpeed()
    {
        enemySpeed = firstSpeed;
    }
}
