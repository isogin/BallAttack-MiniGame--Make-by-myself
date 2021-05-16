using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkourChronos : MonoBehaviour
{
	public GameObject room;
	bool skillOn = true;

	private void Start()
	{
	}
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && skillOn)
		{
			Instantiate(room, this.gameObject.transform.position, Quaternion.identity);
			skillOn = false;
		}

	}
	
}
