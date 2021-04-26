using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2forE : MonoBehaviour
{

    public GameObject bullet;
    public float bulletSpeed;

    public float timeOut;
    private float timeElapsed;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed > timeOut)
        {
            timeElapsed = 0;
            for (int i = 0; i < 8; i++)
            {
                transform.rotation = Quaternion.Euler(0f, i * 45f, 90f);
                Vector3 tmp = this.gameObject.transform.position;
                tmp = new Vector3(tmp.x + 0.7f, tmp.y, tmp.z);

                Instantiate(bullet, tmp, transform.rotation);
                
            }
   
        }
    }

   
} 