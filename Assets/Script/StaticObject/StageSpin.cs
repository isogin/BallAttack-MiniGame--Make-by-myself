using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSpin : MonoBehaviour
{
    public float min;
    public float max;
    public float spinMin;
    public float spinMax;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((min + max) / 100f >= Random.Range(min, max));
        {
            transform.Rotate(new Vector3(0, Random.Range(spinMin, spinMax), 0));
        }
    }
}
