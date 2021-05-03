using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSBallController : MonoBehaviour
{
    //十字キーで玉を動かすための値
    public float playerDefaultSpeed = 30.0f;
    Vector3 x;

    public Rigidbody rb;
    public bool airPosition;

    public float forceMagnitude;

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



        if (Input.GetKey(KeyCode.LeftArrow) && airPosition)
        {
            //現在の速度が遅いほど、加える力を大きくする
            x = new Vector3(-1 * playerDefaultSpeed, 0, 0);
            rb.AddForce(x);
        }
        if (Input.GetKey(KeyCode.RightArrow) && airPosition)
        {
            x = new Vector3(1 * playerDefaultSpeed, 0, 0);
            rb.AddForce(x);
        }
        if (Input.GetKey(KeyCode.UpArrow) && airPosition)
        {
            x = new Vector3(0, 0, 1 * playerDefaultSpeed);

            rb.AddForce(x);
        }
        if (Input.GetKey(KeyCode.DownArrow) && airPosition)
        {
            x = new Vector3(0, 0, -1 * playerDefaultSpeed);
            rb.AddForce(x);
        }


        if (Input.GetKey(KeyCode.Space) && airPosition)
        {
            rb.AddForce(new Vector3(0, jumpPower, 0), ForceMode.Impulse);
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
}