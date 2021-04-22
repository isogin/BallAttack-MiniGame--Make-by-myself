using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public float skillCoolTime;

    public float elapsedTime;
    public bool skillOnPossible;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //クールタイムが経過時間より長い場合
        if(elapsedTime <= skillCoolTime)
        {
            elapsedTime += Time.deltaTime;
        }
        

        if(skillCoolTime <= elapsedTime)
        {
            skillOnPossible = true;
            
        }
       
    }
    public void SkillUsed()
    {
        elapsedTime = 0f;
        skillOnPossible = false;
    }

    public void SkillHalfUsed()
    {
        elapsedTime /= 2f;
        skillOnPossible = false;
    }
}
