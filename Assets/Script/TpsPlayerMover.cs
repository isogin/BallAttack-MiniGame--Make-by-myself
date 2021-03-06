﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TpsPlayerMover : MonoBehaviour
{
    //十字キーで玉を動かすための値
    public float playerDefaultSpeed = 30.0f;
    float x;
    float z;
    public Rigidbody rb;
    public bool airPosition;


    public float collisionImpact;
    public float collisionImpactLImit;

    public float forceMagnitude;
    Vector3 forceD = new Vector3(10.0f, 0f, 0f);
    Vector3 forceA = new Vector3(-10.0f, 0f, 0f);
    Vector3 forceW = new Vector3(0, 0f, 10.0f);
    Vector3 forceS = new Vector3(0f, 0f, -10.0f);
    /// チャージ攻撃発動に必要なカウント
    /// </summary>
    public float invoke_require_count = 5;

    //衝突音の作成
    public AudioSource impactSound;
    /// <summary>
    /// 現在のチャージカウント
    /// </summary>
    public int current_count = 0;

    public float limitSpeed;
    
    /// チャージ攻撃の溜めと発動を行うボタン
    /// </summary>
    protected string input_button_name;


    float inputHorizontal;
    float inputVertical;

    public float jumpPower;
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

        Vector3 camToPlayer = this.gameObject.transform.position - Camera.main.transform.position;
        Vector3 moveRightLeft = camToPlayer + Camera.main.transform.right * x;
        Vector3 moveUpDown = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized * z;


        if (Input.GetKey(KeyCode.LeftArrow) && airPosition)
        {
            x = -1 * playerDefaultSpeed;
            rb.AddForce(moveRightLeft / (rb.velocity.magnitude + 1) * limitSpeed);
            rb.AddForce(0, 3, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && airPosition)
        {
            x = 1 * playerDefaultSpeed;
            rb.AddForce(moveRightLeft / (rb.velocity.magnitude + 1) * limitSpeed);
            rb.AddForce(0, 3, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && airPosition)
        {
            z = 1 * playerDefaultSpeed;
            rb.AddForce(moveUpDown / (rb.velocity.magnitude + 1) * limitSpeed);
            rb.AddForce(0, 3, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow) && airPosition)
        {
            z = -1 * playerDefaultSpeed;
            rb.AddForce(moveUpDown / (rb.velocity.magnitude + 1) * limitSpeed);
            rb.AddForce(0, 3, 0);
        }


        if (Input.GetKey(KeyCode.LeftShift) && airPosition)
        {
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
        }

    }


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
        collisionImpact = other.impulse.magnitude;
        if (other.gameObject.tag == "enemyBall")
        {
            impactSound.PlayOneShot(impactSound.clip);

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
