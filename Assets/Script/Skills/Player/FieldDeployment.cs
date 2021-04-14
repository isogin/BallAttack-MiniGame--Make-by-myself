using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldDeployment : MonoBehaviour
{
    public GameObject shockWave;
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Instantiate(shockWave, player.transform.position, Quaternion.identity);

        }

    }
}
