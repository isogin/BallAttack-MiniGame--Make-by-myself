using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScripts : MonoBehaviour
{
    public GameObject player;
    public float distanceBase = 5f;
    public float awayDistanceBase = 3f;
    public bool touchGround;
    public bool awaynow = false;
    public float xPos;
    public float zPos;
    public Transform awayPos;
    public GameObject destination;
    public bool destinationSet = false;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once p frame
    void Update()
    {
        float distance = distanceBase * Time.deltaTime;
        float awayDistance = awayDistanceBase * Time.deltaTime;

        if(touchGround  == true && awaynow == false)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, player.transform.position, distance);
        }
        if(awaynow == true  && touchGround == true)
        {
            if (destinationSet == true)
            { 
                destination.transform.position = new Vector3(Random.Range(-5.0f, 5.0f), 0.55f, Random.Range(-4.0f, 4.0f));
                destinationSet = false;
            }
                this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, destination.transform.position, awayDistance);

            if(this.gameObject.transform.position == destination.transform.position)
            {
                awaynow = false;
            }
            
        }
        
    }
    private void OnCollisionStay(Collision collision)
    {
        touchGround = true;
    }
    private void OnCollisionExit(Collision collision)
    {
        touchGround = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBall")
        {
            awaynow = true;
            destinationSet = true;
        }
    }
}
