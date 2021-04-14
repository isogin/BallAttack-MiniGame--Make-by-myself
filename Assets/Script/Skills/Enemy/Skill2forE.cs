using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1forE : MonoBehaviour
{
    public GameObject player;
    public GameObject bullet;
    public float bulletSpeed;

    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 8; i++)
            {
                transform.rotation = Quaternion.Euler(0f, i * 45f, 90f);
                Vector3 tmp = GameObject.Find("Player").transform.position;
                tmp = new Vector3(tmp.x + 0.7f, tmp.y, tmp.z);

                Instantiate(bullet, tmp, transform.rotation);
                
            }
   
        }
    }

   
} 