﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : MonoBehaviour
{
    Vector3 homingPos;
    public GameObject homingBullet;


    private void Update()
    {
        homingPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 2, this.gameObject.transform.position.z);
        if (Input.GetKeyDown(KeyCode.U))
        {
            StartCoroutine(TimeCoroutine(0.05f));

        }
    }
    IEnumerator TimeCoroutine(float time)
    {
        for(int i = 0; i < 6; i++)
        {
            Instantiate(homingBullet, homingPos, Quaternion.identity);
            yield return new WaitForSeconds(time);
            
        }
        yield return null;
    }
}
