using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
public class RoomScript : MonoBehaviour
{
    GameObject enemy;
    GameObject player;
    Clock clock;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
        player = GameObject.Find("Player");
        this.gameObject.transform.parent = enemy.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        clock = Timekeeper.instance.Clock("Root");
        //何秒かで消滅する

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "playerBall")
        {
            DelayTime();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "playerBall")
        {
            DefaultTime();
        }
    }

    void DelayTime()
    {
        clock.localTimeScale = 0.5f;
    }
    void DefaultTime()
    {
        clock.localTimeScale = 1;
    }


}
