using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    GameObject enemy;

   //十字キーで玉を動かすための値
    public float playerDefaultSpeed;

    public Rigidbody rb;
    public bool airPosition;

    public float forceMagnitude;

    /// チャージ攻撃発動に必要なカウント

    public  float invoke_require_count = 5;
    //衝突音の作成
    public AudioSource impactSound;
    /// <summary>
    /// 現在のチャージカウント
    /// </summary>
    public int current_count = 0;

    public float collisionImpact;
    public float collisionImpactLimit;
    public float halfPowerTime;

    float halfSpeed;
    float firstSpeed;
    //チャージアタックのクールタイムの実装
    public bool spaceJudge = true;
    public float changeTime = 1.3f;
    Material myMaterial;

    bool halfPowerDone = false;

    public float explosionPower;
    public float radius;

    public float firstForce;

    Vector3 latestPos;
    Vector3 x;

    float angle;
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        rb = GetComponent<Rigidbody>();
     
    impactSound = GetComponent<AudioSource>();

        myMaterial = GetComponent<Renderer>().material;

        halfSpeed = playerDefaultSpeed * 0.5f;
        firstSpeed = playerDefaultSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        Vector3 diff = this.gameObject.transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = this.gameObject.transform.position;  //前回のPositionの更新

        if (Input.GetKey(KeyCode.LeftArrow) && airPosition)
        {
            //現在の速度が遅いほど、加える力を大きくする
            x = new Vector3(-1 * playerDefaultSpeed, 0,0);
            rb.AddForce(x);
        }
        if (Input.GetKey(KeyCode.RightArrow) && airPosition)
        {
            x = new Vector3(1 * playerDefaultSpeed, 0, 0);
            rb.AddForce(x);
        }
        if (Input.GetKey(KeyCode.UpArrow) && airPosition)
        {
            x = new Vector3(0, 0,1 * playerDefaultSpeed);

            rb.AddForce(x);
        }
        if (Input.GetKey(KeyCode.DownArrow) && airPosition)
        {
            x =new Vector3(0, 0, -1 * playerDefaultSpeed);
            rb.AddForce(x);
        }
        //慣性無効補正
        if (Input.GetKeyDown(KeyCode.LeftArrow) && airPosition)
        {
            angle = Vector3.Angle(x, diff);
            rb.AddForce(x * angle * firstForce * 0.0001f, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow) && airPosition)
        {
            angle = Vector3.Angle(x, diff);
            rb.AddForce(x * angle * firstForce * 0.0001f, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.UpArrow) && airPosition)
        {
            angle = Vector3.Angle(x, diff);
            rb.AddForce(x * angle * firstForce * 0.0001f, ForceMode.Impulse);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow) && airPosition)
        {
            angle = Vector3.Angle(x, diff);
            rb.AddForce(x * angle * firstForce * 0.0001f, ForceMode.Impulse);
        }


    }

/// <summary>


void Update()
    {

    }



    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemyBall")
        {
            impactSound.PlayOneShot(impactSound.clip);

            collisionImpact = other.impulse.magnitude;

            if (collisionImpact > collisionImpactLimit)
            {
                halfPowerDone = true;
            }
            if (halfPowerDone)
            {
                playerDefaultSpeed = playerDefaultSpeed * 0.5f;
                Invoke("HalfPowerFinish", halfPowerTime);
                halfPowerDone = false;
            }

        }
    }
    private void OnCollisionStay(Collision collision)
    {
        airPosition = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        airPosition = false;
    }
    void MassChange()
    {
        rb.mass = 2;
    }

    public void Explosion (Vector3 explosionPOs, float explosionIndex)
    {
        rb.AddExplosionForce(explosionPower * explosionIndex, explosionPOs, radius, 3.0F);
    }



    void SpaceBool()
    {
        spaceJudge = true;
    }

    void HalfPowerFinish()
    {
        playerDefaultSpeed = playerDefaultSpeed * 2;
    }
}

