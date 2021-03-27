using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShockWaveObject : MonoBehaviour
{
    float time;
    public float lifeTiem;
    public float bigMagnitude;
    byte colorFirst = 255;
    byte color1 = 1;
    MeshRenderer mr;
    // Start is called before the first frame update
    void Start()
    {
        mr = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(time >= lifeTiem)
        {
            colorFirst -= color1;
            time = 0.0f;
        }
        colorFirst -= color1;
        time += Time.deltaTime;
        this.gameObject.transform.localScale += new Vector3(bigMagnitude , bigMagnitude * 0.3f, bigMagnitude);

        mr.material.color = new Color32(1, 0, 77,colorFirst);
        if(colorFirst == 0)
        {
            Destroy(gameObject);
        }
    }
}
