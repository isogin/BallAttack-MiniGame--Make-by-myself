using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchActive : MonoBehaviour
{
    public GameObject activeObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "PlayerBall")
        {
            StartCoroutine("Active");
        }

    }
    IEnumerator Active()
    {
        yield return new WaitForSeconds(2f);
        activeObject.SetActive(true);

    }
}
