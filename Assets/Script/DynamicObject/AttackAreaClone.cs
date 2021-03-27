using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAreaClone : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 attackAreaIndex = player.transform.position - new Vector3(0, player.transform.position.y, 0);
        float attackAreaMagnitude = attackAreaIndex.magnitude * 0.8f;
        this.gameObject.transform.localScale = new Vector3(attackAreaMagnitude, attackAreaMagnitude, attackAreaMagnitude);

    }
}
