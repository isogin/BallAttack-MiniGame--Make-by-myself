using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
public class ChrnosSkill1forE : ChronosBaseBehavior
{
	private float moveSpeed = 1.0f;
    public GameObject room;
    private void Start()
    {
        Instantiate(room, this.gameObject.transform.position,Quaternion.identity);
    }
    void Update()
	{

	}
}
