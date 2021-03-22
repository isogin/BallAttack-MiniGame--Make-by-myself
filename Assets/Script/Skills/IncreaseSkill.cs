using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSkill : MonoBehaviour
{
    public float timeOut;
    private float timeElapsed;
    public GameObject IncreaseObject;
    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            // Do anything
            Instantiate(IncreaseObject, this.gameObject.transform.position, Quaternion.identity);
            timeOut = timeOut * 2;
            timeElapsed = 0.0f;
        }
    }
}
