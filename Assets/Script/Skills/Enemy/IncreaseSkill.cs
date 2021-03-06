﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSkill : MonoBehaviour
{
    public float timeOut;
    private float timeElapsed;
    public GameObject increaseObject;
    EnemyClone increaseScript;

    GameObject increaseObjectClone;
    Rigidbody rb;
    Rigidbody rb2;
    public float power;
    public float radius = 3.0f;

    public GameObject increaseEffect;

    bool skillFinish = true;
    private void Start()
    {
        increaseScript = increaseObject.GetComponent<EnemyClone>();


    }
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= timeOut && skillFinish)
        {

            increaseObjectClone = Instantiate(increaseObject,this.gameObject.transform.position,Quaternion.identity) as GameObject;
            StartCoroutine("IncreaseEffect");

            timeElapsed = 0.0f;
            rb = this.gameObject.GetComponent<Rigidbody>();
            rb2 = increaseObjectClone.GetComponent<Rigidbody>();

            skillFinish = false;
            Invoke("Finish", increaseScript.lifeTime);
        }
    }
    IEnumerator IncreaseEffect()
    {
        Instantiate(increaseEffect, this.gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Vector3 explosionPos = transform.position - increaseObjectClone.transform.position;
        rb2 = increaseObject.GetComponent<Rigidbody>();
        rb.AddExplosionForce(power, explosionPos, radius, 3.0f);
        rb2.AddExplosionForce(power, explosionPos, radius, 3.0f);

    }
    void Finish()
    {
        timeElapsed = 0;
        skillFinish = true;
    }
}
