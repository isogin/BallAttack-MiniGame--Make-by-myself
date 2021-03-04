using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("ParticlesDestroy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator ParticlesDestroy()
    {
        yield return new WaitForSeconds(2);
        Destroy(this.gameObject);
    }
     
}
