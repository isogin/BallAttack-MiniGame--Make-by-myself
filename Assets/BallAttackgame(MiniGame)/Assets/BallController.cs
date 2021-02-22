﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
   //十字キーで玉を動かすための値
    public float speed = 30.0f;
    float x;
    float z;
    public Rigidbody rb;

    public float forceMagnitude = 10.0f;
    Vector3 force = new Vector3(10.0f, 0f, 0f);
    /// チャージ攻撃発動に必要なカウント
    /// </summary>
    public  float invoke_require_count = 5;
    
    //衝突音の作成
    public AudioSource impactSound;
    /// <summary>
    /// 現在のチャージカウント
    /// </summary>
    protected int current_count = 0;

    /// <summary>
    /// チャージ攻撃の溜めと発動を行うボタン
    /// </summary>
    protected string input_button_name;

    //チャージアタックのクールタイムの実装
    public bool spaceJudge = true;
    public float changeTime = 1.3f;
    Material myMaterial;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
     
    impactSound = GetComponent<AudioSource>();

        myMaterial = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            x = -1 * speed;
            rb.AddForce(x, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            x = 1 * speed;
            rb.AddForce(x, 0, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            z = 1 * speed;
            rb.AddForce(0, 0, z);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            z = -1 * speed;
            rb.AddForce(0, 0, z);
        }
        


        Vector3 forcefinal = forceMagnitude * force;

        // ボタンを離した際に一定値以上カウントが溜まっていればアクション実行
        if (Input.GetKey(KeyCode.D) && spaceJudge)
        {

            if (invoke_require_count <= current_count)
            {
                current_count = 0;
                ChargeAttackCoolTime();
                rb.AddForce(forcefinal, ForceMode.Impulse);
                rb.mass = 5;
                Invoke("MassChange", changeTime);

            }
        }
        if (Input.GetKey(KeyCode.D))
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
            rb.AddForce(0, 100, 0);
            GetComponent<ParticleSystem>().Play();
        }
       
    }
    void MassChange()
    {
        rb.mass = 2;
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
}

