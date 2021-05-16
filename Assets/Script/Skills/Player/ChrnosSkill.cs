using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
public class ChrnosSkill : MonoBehaviour
{
	public GameObject room;
	SkillController skillController;
	public GameObject skillControllObject;


	private void Start()
	{
		skillController = skillControllObject.GetComponent<SkillController>();
	}
    void Update()
	{
		if(Input.GetKeyDown(KeyCode.Space) && skillController.skillOnPossible)
        {
			Instantiate(room, this.gameObject.transform.position, Quaternion.identity);

			skillController.SkillUsed();
		}
		
	}
}
