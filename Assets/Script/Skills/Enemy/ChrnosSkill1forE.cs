using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
public class ChrnosSkill1forE : MonoBehaviour
{
	private float moveSpeed = 1.0f;
    public GameObject room;
    bool timeSkillOn = false;
    private void Start()
    {
        
    }
    void Update()
	{
      if(timeSkillOn)
        {
            Instantiate(room, this.gameObject.transform.position, Quaternion.identity);
        }
	}
}
