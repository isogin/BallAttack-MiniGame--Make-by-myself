using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;

public class TimeControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            if (GetComponent<GlobalClock>().localTimeScale == 0)
                GetComponent<GlobalClock>().localTimeScale = 1;
            else
                GetComponent<GlobalClock>().localTimeScale = 0;
        }
    }
}
