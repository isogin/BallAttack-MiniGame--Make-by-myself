using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillCoolTime : MonoBehaviour
{
    Image gaugeCtrl;

    SkillController skillController;
    public GameObject SkillControllObject;

    public float x;

    float percentage;
    // Start is called before the first frame update
    void Start()
    {
        gaugeCtrl = GetComponent<Image>();

        skillController = SkillControllObject.GetComponent<SkillController>();

        percentage = skillController.skillCoolTime;
    }

    // Update is called once per frame
    void Update()
    {
        gaugeCtrl.fillAmount = skillController.elapsedTime / percentage;


    }
}
