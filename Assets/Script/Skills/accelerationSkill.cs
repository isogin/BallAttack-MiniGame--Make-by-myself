using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class accelerationSkill : MonoBehaviour
{
    GameObject player;
    Rigidbody rb;
    private Vector3 latestPos;
    public float acceleratePower;
    public Vector3 diff;

    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        diff = (player.transform.position - latestPos).normalized;
        latestPos = player.transform.position;
        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.velocity = diff * acceleratePower;
            Invoke("StopAccelerate", 0.2f);
        }
        
    }

    void StopAccelerate()
    {
        rb.velocity = diff * acceleratePower * 0.5f;
    }
}
