using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterObject : MonoBehaviour
{
    bool comeOnPlayer;
    public GameObject setObject;
    public GameObject Ball;
    float elapsedTime;
    float timeOut;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!(setObject))
        {
            comeOnPlayer = true;
        }
        if(comeOnPlayer)
        {
            timeOut = Random.Range(3, 4);
            elapsedTime += Time.deltaTime;
        }
        if(elapsedTime > timeOut)
        {
            elapsedTime = 0;
            Instantiate(Ball, this.gameObject.transform.position, Quaternion.identity);
            
        }
    }
}
