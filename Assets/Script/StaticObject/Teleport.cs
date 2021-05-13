using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public Rigidbody rb;
    GameObject player;
    public GameObject teleport;
    Vector3 teleportPos;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        teleportPos = teleport.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "PlayerBall") ;
        {

            player.transform.position = teleportPos;
            rb.angularVelocity = Vector3.zero;
            rb.velocity = Vector3.zero;
        }
    }
}
