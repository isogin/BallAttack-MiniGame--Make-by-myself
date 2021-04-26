using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Chronos;
public class ChrnosSkill1forE : MonoBehaviour
{
    public GameObject room;

    public float timeOut;
    private float timeElapsed;

    bool firstSkillEffect = true;
    private void Start()
    {
        
    }
    void Update()
	{
        timeElapsed += Time.deltaTime;
      if(timeElapsed >= timeOut)
        {
            if(firstSkillEffect)
            {
                timeOut += 5;
            }

            timeElapsed = 0;
            Instantiate(room, this.gameObject.transform.position, Quaternion.identity);
        }
	}
}
