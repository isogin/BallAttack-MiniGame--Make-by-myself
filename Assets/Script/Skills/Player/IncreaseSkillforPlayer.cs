using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseSkillforPlayer : MonoBehaviour
{
    public float timeOut;
    private float timeElapsed;
    public GameObject increaseObject;
    GameObject increaseObjectClone;
    Rigidbody rb;
    Rigidbody rb2;
    public float power;
    public float radius = 3.0f;

    public GameObject increaseEffect;
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.B))
        {

            increaseObjectClone = Instantiate(increaseObject, this.gameObject.transform.position, Quaternion.identity) as GameObject;
            StartCoroutine("IncreaseEffect");

            timeElapsed = 0.0f;
            rb = this.gameObject.GetComponent<Rigidbody>();
            rb2 = increaseObjectClone.GetComponent<Rigidbody>();
        }
    }
    IEnumerator IncreaseEffect()
    {
        Instantiate(increaseEffect, this.gameObject.transform.position, Quaternion.identity);
        yield return new WaitForSeconds(0.1f);
        Vector3 explosionPos = this.gameObject.transform.position - increaseObjectClone.transform.position;
        rb2 = increaseObject.GetComponent<Rigidbody>();
        rb.AddExplosionForce(power, explosionPos, radius, 3.0f);
        rb2.AddExplosionForce(power, explosionPos, radius, 3.0f);

    }
}
