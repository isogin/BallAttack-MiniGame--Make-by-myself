using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1 : MonoBehaviour
{
    public GameObject bullet;
    public float bulletSpeed;

    public GameObject skillControllObject;
    SkillController skillController;

    // Use this for initialization
    void Start()
    {

        skillController = skillControllObject.GetComponent<SkillController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && skillController.skillOnPossible)
        {
            skillController.SkillUsed();
            for (int i = 0; i < 8; i++)
            {
                transform.rotation = Quaternion.Euler(0f, i * 45f, 90f);
                Vector3 tmp = this.gameObject.transform.position;
                tmp = new Vector3(tmp.x + 0.7f, tmp.y, tmp.z);

                Instantiate(bullet, tmp, transform.rotation);
                
            }
            
   
        }
    }

   
} 