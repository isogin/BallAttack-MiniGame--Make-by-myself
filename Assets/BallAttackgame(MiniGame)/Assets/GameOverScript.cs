using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScript : MonoBehaviour
{
    bool isEnd = false;
    public GameObject stateText;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PlayerBall")
        {
            this.isEnd = true;
           
        }
        if(other.gameObject.tag == "enemyBall")
        {
            this.isEnd = true;
           
        }
      
    }
}
