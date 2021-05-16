using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public GameObject elevatorObject;
    public float moverSpeed;
    Vector3 pos;
    public float moveTime;
    bool moveOn = false;
    public float startTime;
    void Start()
    {
        pos = elevatorObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(moveOn)
        {
            pos.y += moverSpeed;
            elevatorObject.transform.position = pos;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBall")
        {
            StartCoroutine("StartUp");
        }
    }

    IEnumerator StartUp()
    {
        yield return new WaitForSeconds(startTime);
        moveOn = true;
        yield return new WaitForSeconds(moveTime);

        moveOn = false;

    }
}
