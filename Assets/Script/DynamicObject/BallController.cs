using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    GameObject enemy;

   //十字キーで玉を動かすための値
    public float playerDefaultSpeed;
    float x;
    float z;
    public Rigidbody rb;
    public bool airPosition;

    public float forceMagnitude;
    Vector3 forceD = new Vector3(10.0f, 0f, 0f);
    Vector3 forceA = new Vector3(-10.0f, 0f, 0f);
    Vector3 forceW = new Vector3(0, 0f, 10.0f);
    Vector3 forceS = new Vector3(0f, 0f, -10.0f);
    /// チャージ攻撃発動に必要なカウント
    /// </summary>
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
    // Start is called before the first frame update
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
        


        if(Input.GetKey(KeyCode.LeftArrow) && airPosition)
        {
            x = -1 * playerDefaultSpeed;
            rb.AddForce(x, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && airPosition)
        {
            x = 1 * playerDefaultSpeed;
            rb.AddForce(x, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && airPosition)
        {
            z = 1 * playerDefaultSpeed;
            rb.AddForce(0, 0, z);
        }
        if (Input.GetKey(KeyCode.DownArrow) && airPosition)
        {
            z = -1 * playerDefaultSpeed;
            rb.AddForce(0, 0, z);
        }

        // ボタンを離した際に一定値以上カウントが溜まっていればアクション実行
        if (Input.GetKey(KeyCode.D) && spaceJudge)
        {
            if (invoke_require_count <= current_count)
            {
                Vector3 forcefinal = forceMagnitude * forceD;
                current_count = 0;
                ChargeAttackCoolTime();
                rb.AddForce(forcefinal, ForceMode.Impulse);
                rb.mass = 5;
                Invoke("MassChange", changeTime);

            }
        }


        if (Input.GetKey(KeyCode.A) && spaceJudge)
        {
            if (invoke_require_count <= current_count)
            {
                Vector3 forcefinal = forceMagnitude * forceA;
                current_count = 0;
                ChargeAttackCoolTime();
                rb.AddForce(forcefinal, ForceMode.Impulse);
                rb.mass = 5;
                Invoke("MassChange", changeTime);

            }
        }

        if (Input.GetKey(KeyCode.W) && spaceJudge)
        {
            if (invoke_require_count <= current_count)
            {
                Vector3 forcefinal = forceMagnitude * forceW;
                current_count = 0;
                ChargeAttackCoolTime();
                rb.AddForce(forcefinal, ForceMode.Impulse);
                rb.mass = 5;
                Invoke("MassChange", changeTime);

            }
        }



        if (Input.GetKey(KeyCode.S) && spaceJudge)
        {
            if (invoke_require_count <= current_count)
            {
                Vector3 forcefinal = forceMagnitude * forceS;
                current_count = 0;
                ChargeAttackCoolTime();
                rb.AddForce(forcefinal, ForceMode.Impulse);
                rb.mass = 5;
                Invoke("MassChange", changeTime);

            }
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.W))
        {
            current_count++;
        }
        else
        {
            // ボタンを離した場合はリセット
            current_count = 0;
        }

    }

/// <summary>


void Update()
    {

    }
    public float PropChargeCount()
    {
        // 既に溜まっている場合は1を返す
        if (invoke_require_count <= current_count)
        {
            return 1f;
        }
        // float型にキャストして割合を計算
        return (float)current_count / (float)invoke_require_count;
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

    void ChargeAttackCoolTime()
    {
        spaceJudge = false;
        Invoke("SpaceBool", 5.0f);
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

