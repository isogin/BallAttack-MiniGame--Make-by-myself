using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageDestroyScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StageDestoroy");
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator StageDestoroy()
    {
        yield return new WaitForSeconds(3);
        Destroy(this.gameObject);
    }

}