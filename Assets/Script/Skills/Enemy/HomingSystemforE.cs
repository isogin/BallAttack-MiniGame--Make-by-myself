﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomingSystemforE : MonoBehaviour
{
    //Rigidbodyを入れる変数
    Rigidbody rigid;
    //速度
    Vector3 velocity;
    //発射するときの初期位置
    Vector3 position;
    // 加速度
    public Vector3 acceleration;
    // ターゲットをセットする
    public Transform target;
    // 着弾時間
    float period = 2f;

    public GameObject particleObject;
    GameObject player;
    public BallController playerScript;

    public float explosionIndex;

    GameObject enemy;
    Skill6forE enemyScript;

    public float lifeTime;
    float timeElapsed;
    void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        playerScript = player.GetComponent<BallController>();
        // 初期位置をposionに格納
        position = transform.position;
        // rigidbody取得
        rigid = this.GetComponent<Rigidbody>();
        rigid.AddForce(new Vector3(0, 10f, 0), ForceMode.Impulse);

        enemyScript = enemy.GetComponent<Skill6forE>();

        enemyScript.skillFinish = false;
    }


    void Update()
    {
        timeElapsed = Time.deltaTime;
        if(timeElapsed > lifeTime)
        {
            playerScript.Explosion(this.gameObject.transform.position, explosionIndex);
            //パーティクルの発生
            Instantiate(particleObject, this.transform.position, Quaternion.identity);

            enemyScript.timeElapsed = 0;
            enemyScript.skillFinish = true;
            // 何かに当たったら自分自身を削除
            Destroy(this.gameObject);
        }
        acceleration = Vector3.zero;

        target = player.transform;
        //ターゲットと自分自身の差
        var diff = target.position - transform.position;

        //加速度を求めてるらしい
        acceleration += (diff - velocity * period) * 2f
                        / (period * period);


        //加速度が一定以上だと追尾を弱くする
        if (acceleration.magnitude > 100f)
        {
            acceleration = acceleration.normalized * 100f;
        }

        // 着弾時間を徐々に減らしていく
        period -= Time.deltaTime;

        // 速度の計算
        velocity += acceleration * Time.deltaTime;

    }

    void FixedUpdate()
    {
        // 移動処理
        rigid.MovePosition(transform.position + velocity * Time.deltaTime);
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "enemyBall" || other.gameObject.tag == "Stage")
        {
            playerScript.Explosion(this.gameObject.transform.position, explosionIndex);
            //パーティクルの発生
            Instantiate(particleObject, this.transform.position, Quaternion.identity);

            enemyScript.timeElapsed = 0;
            enemyScript.skillFinish = true;
            // 何かに当たったら自分自身を削除
            Destroy(this.gameObject);

        }

    }
}
