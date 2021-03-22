
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{

    public  GameObject player;   //プレイヤー情報格納用
    public GameObject enemy;
    private Vector3 offset;      //相対距離取得用

    void Update()
    {
        transform.LookAt(enemy.transform, Vector3.up);
        this.transform.position = player.transform.position;

    }

}
