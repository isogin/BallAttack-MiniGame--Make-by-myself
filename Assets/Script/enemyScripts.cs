using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScripts : MonoBehaviour
{
    public GameObject player;
    public BallController playerScript;
    public float distanceBase = 5f;
    public float awayDistanceBase = 3f;
    public bool touchGround;
    public bool awaynow = false;
    public float xPos;
    public float zPos;
    public Transform awayPos;
    public GameObject destination;
    public bool destinationSet = false;
    public Rigidbody rb;
    public float explosionPower;
    public float radius;
    public bool setRunPosition = false;
    public Vector3 playerSetPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<BallController>();
    }

    // Update is called once p frame
    void Update()
    {
        Debug.Log(setRunPosition);
        float distance = distanceBase * Time.deltaTime;
        float awayDistance = awayDistanceBase * Time.deltaTime;

        //enemyが地面にいて、攻撃状態のとき
        if(touchGround  == true && awaynow == false)
        {
            //攻撃位置が指定されていない状態で、プレイヤーが地面についているとき
            if (setRunPosition == false && playerScript.airPosition)
            {
                SetRunPosition();
                Debug.Log("これから攻撃位置をしていします");
            }
            //enemyを攻撃位置に移動させる
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, playerSetPosition, distance);

            //enemyが攻撃位置に着いたとき
            if (this.gameObject.transform.position.x == playerSetPosition.x && this.gameObject.transform.position.z == playerSetPosition.z)
            {
                //逃げる状態にして、逃げ位置を指定する
                awaynow = true;
                destinationSet = true;
                Debug.Log("setPosition array");
            }
        }
        //enemyが地面にいて、逃げる状態であるとき
        if(awaynow == true  && touchGround == true)
        {
            if (destinationSet == true)
            { 
                destination.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), 0.55f, Random.Range(-4.0f, 4.0f));
                destinationSet = false;
            }
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, awayDistance);

            //enemyが逃げる位置に着いたとき
            if(this.gameObject.transform.position.x == destination.transform.position.x && this.gameObject.transform.position.z == destination.transform.position.z)
            {
                awaynow = false;
                setRunPosition = false;
                Debug.Log("enemy array backposition");

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
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBall")
        {

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
        Debug.Log("攻撃位置セット完了！！");
    }
       
}

