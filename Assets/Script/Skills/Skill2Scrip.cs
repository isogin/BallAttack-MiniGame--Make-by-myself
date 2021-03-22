using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill2Scrip : MonoBehaviour
{
    public GameObject enemy;
    public GameObject skill2Object;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.Find("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 enemyPos = enemy.transform.position;
        enemyPos = new Vector3(enemyPos.x , enemyPos.y + 2, enemyPos.z);
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject go = Instantiate(skill2Object) as GameObject;
            go.transform.position = new Vector3(enemyPos.x, enemyPos.y + 2, enemyPos.z);
        }
    }
}
