using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookOnCamera : MonoBehaviour
{
    GameObject target;
    GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("Enemy");
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(target.transform, Vector3.up);
    }

    
}

