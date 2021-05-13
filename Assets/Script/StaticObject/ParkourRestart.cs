using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourRestart : MonoBehaviour
{
    GameObject player;
    Vector3 firstPlayerPos;
    Vector3 firstCameraPos;
    GameObject camera;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        camera = GameObject.Find("MainCamera");
        player = GameObject.Find("Player");
        rb = player.GetComponent<Rigidbody>();
;       firstPlayerPos = player.transform.position;
        firstCameraPos = camera.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBall")
        {
            rb.velocity = Vector3.zero;
            player.transform.position = firstPlayerPos;
            camera.transform.position = firstCameraPos;
        }

    }
}
