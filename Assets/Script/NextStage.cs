using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextStage : MonoBehaviour
{
    bool oneTime = true;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "PlayerBall" && oneTime)
        {
            StatusModelSinglton.Instance.NextScene();
            oneTime = false;
            
        }
        
    }
}
