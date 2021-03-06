using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineSample : MonoBehaviour
{
    bool isCollided = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TimeCoroutine(3.0f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimeCoroutine(float time)
    {
        while (isCollided)
        {
            Debug.Log("Loop");
            yield return new WaitForSeconds(time);
        }
        yield return null;
    }

    private void OnCollisionEnter(Collision collision)
    {
        isCollided = true;
    }
}
