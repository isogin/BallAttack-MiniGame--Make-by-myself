using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSkill : MonoBehaviour
{
    GameObject player;
    ParkourAcceleration playerSkill;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerSkill = player.GetComponent<ParkourAcceleration>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        playerSkill.enabled = true;

        Destroy(this.gameObject);
    }
}
