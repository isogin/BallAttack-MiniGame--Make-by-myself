using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScripts : MonoBehaviour
{
    public Rigidbody rb2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "playerBall")
        {
            rb2.AddForce(0, 150, 0);
        }
       
    }
}
