using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generate : MonoBehaviour
{
    public float timeOut;
    public float elapsedTime = 0;
    public GameObject waveObject;
    public GameObject eventObject;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!(eventObject))
        {
            elapsedTime += Time.deltaTime;
            if (timeOut < elapsedTime)
            {
                Instantiate(waveObject, this.gameObject.transform.position, Quaternion.identity);
                elapsedTime = 0;
            }
        }

    }
}
