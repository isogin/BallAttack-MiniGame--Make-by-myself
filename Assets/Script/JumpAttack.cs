using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpAttack : MonoBehaviour
{

    Rigidbody rb;
    public float upForce;
    public Vector3 scale;
    Vector3 startScale;
    public float changeMass;
    float startMass;
    public BallController playerScript;
    bool airPosition;
    float playerDS;
    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        startScale = this.gameObject.transform.localScale;
        startMass = rb.mass;
    }
    private void Update()
    {
        //ボールコントローラースクリプトから変数を取得
        airPosition = playerScript.airPosition;
        playerDS = playerScript.playerDefaultSpeed;


        Vector3 boost = new Vector3(0, upForce, 0);
        if (Input.GetKey(KeyCode.F))
        {
            rb.AddForce(boost);

        }

        //空中制御を可能に
        if (Input.GetKey(KeyCode.LeftArrow) && airPosition  == false)
        {
            float x = -0.2f * playerDS;
            rb.AddForce(x,0,0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && airPosition == false)
        {
             float x = 0.2f * playerDS;
            rb.AddForce(x,0,0);
        }
        if (Input.GetKey(KeyCode.UpArrow) && airPosition == false)
        {
            float z = 0.2f * playerDS;
            rb.AddForce(0, 0, z);
        }
        if (Input.GetKey(KeyCode.DownArrow) && airPosition == false)
        { 
            float z = -0.2f * playerDS;
            rb.AddForce(0, 0 ,z);
        }


        if (Input.GetKeyDown(KeyCode.F) && airPosition)
        {
            rb.AddForce(0, 1.5f, 0, ForceMode.Impulse);
        }

            if (airPosition == false)
        {
            rb.AddForce(0, -2.5f, 0);
        }
    }

       
}
