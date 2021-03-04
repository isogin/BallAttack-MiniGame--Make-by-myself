using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Object : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // transformを取得
        Transform myTransform = this.transform;
        // 現在の座標からのxyz を1ずつ加算して移動
        myTransform.Translate(0, 0.005f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }

}
