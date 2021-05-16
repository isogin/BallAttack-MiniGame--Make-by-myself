using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantTeleport : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    public GameObject teleport;
    Vector3 teleportPos;
    void Start()
    {
        teleportPos = teleport.transform.position;
        rb = player.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBall")
        {
            Invoke("TeleportOn", 4);
        }
    }

    void TeleportOn()
    {
        player.transform.position = teleportPos;
        rb.angularVelocity = Vector3.zero;
        rb.velocity = Vector3.zero;
    }
}
