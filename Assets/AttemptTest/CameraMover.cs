
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    GameObject player;
    public GameObject camera;
    public float rotateSpeed = 3.0f;
    private Vector3 latestPos;

    public GameObject downViewPos;
    private void Start()
    {
        player = GameObject.Find("Player");

    }
    private void Update()
    {
        this.gameObject.transform.position = player.transform.position;
        Vector3 playerPos = player.transform.position;
        Vector3 diff = transform.position - latestPos;   //前回からどこに進んだかをベクトルで取得
        latestPos = transform.position;


        if (Input.GetKey(KeyCode.D))
        {
            transform.RotateAround(playerPos, new Vector3(0, 1, 0), rotateSpeed);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.RotateAround(playerPos, new Vector3(0, 1, 0), -rotateSpeed);
        }
        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(new Vector3(-rotateSpeed * 0.1f , 0, 0));
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(new Vector3(rotateSpeed * 0.1f, 0, 0));
        }
        if (Input.GetKey(KeyCode.Space))
        {
            camera.transform.position = downViewPos.transform.position;
        }

    }

    
}