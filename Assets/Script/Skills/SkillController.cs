using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillController : MonoBehaviour
{
    public float skillCoolTime;

    public float elapsedTime;
    public bool skillOnPossible;
    public bool skillOnHalfPossible;

    public bool skillUseNow = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //クールタイムが経過時間より長い場合
        if(elapsedTime <= skillCoolTime && skillUseNow == false)
        {
            elapsedTime += Time.deltaTime;
        }
        

        if(skillCoolTime <= elapsedTime)
        {
            skillOnPossible = true;
            
        }
        if (skillCoolTime / 2 <= elapsedTime)
        {
            skillOnHalfPossible = true;

        }


    }
    public void SkillUsed()
    {
        elapsedTime = 0f;
        skillUseNow = true;
        skillOnPossible = false;
    }
    public void SkillFinish()
    {
        skillUseNow = false;
    }

    public void SkillHalfUsed()
    {
        elapsedTime /= 2f;
        skillUseNow = true;
        skillOnHalfPossible = false;
    }
}
