using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScripts : MonoBehaviour
{
    public GameObject player;
    public TpsPlayerMover playerScript;
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
    public GameObject enemyDestinationalAreaClone;
    public GameObject enemyAttackArea;
    public GameObject enemyAttackAreaClone;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<TpsPlayerMover>();
    }

    // Update is called once p frame
    void Update()
    {

        //enemyが地面にいて、攻撃状態のとき
        if (touchGround  == true && awaynow == false)
        {
            //攻撃位置が指定されていない状態で、プレイヤーが地面についているとき
            if (setRunPosition == false && playerScript.airPosition)
            {
                SetRunPosition();
                
            }
            //プレイヤーの位置へ力を加える
            Vector3 enemyAttack = playerSetPosition - this.gameObject.transform.position;
            //enemyを攻撃位置に移動させる
            rb.AddForce(enemyAttack * enemySpeed);

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
                
                destination.transform.position = new Vector3(Random.Range(-2.0f, 2.0f), 0.55f, Random.Range(-2.0f, 2.0f));
                enemyDestinationalAreaClone = Instantiate(enemyDestinationalArea, destination.transform.position, this.gameObject.transform.rotation) as GameObject;
                destinationSet = false;
                
                }
                //逃げる位置へ力を加える
            Vector3 RunAwayPosition = destination.transform.position - this.gameObject.transform.position;
            rb.AddForce(RunAwayPosition * enemySpeed);

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
            Debug.Log("にげるいちにとうちゃく");

        }
        if (other.gameObject.tag == "EnemyAttackArea")

        {
            Destroy(enemyAttackAreaClone);
            awaynow = true;
            destinationSet = true;
            Debug.Log("攻撃するいちにとうちゃく");
        }
    }
    public void Skill3Discharge(Vector3 explosionPOs)
    {
        rb.AddExplosionForce(explosionPower, explosionPOs, radius, 3.0F);
    }

    public void SetRunPosition()
    {
        playerSetPosition = player.transform.position;
        //攻撃位置指定完了！！
        setRunPosition = true;
        enemyAttackAreaClone = Instantiate(enemyAttackArea, player.transform.position, this.gameObject.transform.rotation) as GameObject;
    }
       
}

