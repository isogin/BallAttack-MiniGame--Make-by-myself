using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourRoom : MonoBehaviour
{
    GameObject player;
    GameObject obstacleObject;


    public GameObject particleObject;


    bool wherePlayer;

    void Start()
    {

        player = GameObject.Find("Player");

        this.gameObject.transform.parent = player.gameObject.transform;




       
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "RoomObject")
        {
            var rigid = other.gameObject.GetComponent<Rigidbody>();
            rigid.velocity *= 0.1f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "RoomObject")
        {
            var rigid = other.gameObject.GetComponent<Rigidbody>();

            rigid.velocity *= 10;
        }

    }


}
