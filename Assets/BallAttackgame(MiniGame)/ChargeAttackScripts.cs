using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeAttackScripts : MonoBehaviour
{
    Vector3 forceD = new Vector3(10.0f, 0f, 0f);
    Vector3 forceA= new Vector3(-10.0f, 0f, 0f);
    Vector3 forceW = new Vector3(0, 0f, 10.0f);
    Vector3 forceS= new Vector3(10.0f, 0f, -10.0f);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var spaceJudge = GetComponent<BallController>().spaceJudge;
        var invoke_require_count = GetComponent<BallController>().invoke_require_count;
        var current_count = GetComponent<BallController>().current_count;
        var forceMagnitude = GetComponent<BallController>().forceMagnitude;
        var rb = GetComponent<BallController>().rb;
        var changeTime = GetComponent<BallController>().changeTime;

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
        if (Input.GetKey(KeyCode.D))
            current_count++;
        else
            // ボタンを離した場合はリセット
            current_count = 0;


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
        if (Input.GetKey(KeyCode.A))
            current_count++;
        else
            // ボタンを離した場合はリセット
            current_count = 0;

        
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
        if (Input.GetKey(KeyCode.W))
            current_count++;
        else
            // ボタンを離した場合はリセット
            current_count = 0;


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
        if (Input.GetKey(KeyCode.S))
        {
            current_count++;
        }
        else
            // ボタンを離した場合はリセット
            current_count = 0;

    }
    void ChargeAttackCoolTime()
    {
        Debug.Log("saikyou");
    }
        
}
