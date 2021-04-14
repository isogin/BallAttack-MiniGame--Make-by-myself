using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
public class ChronosBaseBehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public Timeline time
    {
        get
        {
            return GetComponent<Timeline>();
        }
    }
        
}
