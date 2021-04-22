using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill4 : MonoBehaviour
{
    Vector3 homingPos;
    public GameObject homingBullet;

    public float bulletRemain;

    public GameObject skillControllObject;
    SkillController skillController;
    private void Start()
    {
        skillController = skillControllObject.GetComponent<SkillController>();
    }
    private void Update()
    {
        homingPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 2, this.gameObject.transform.position.z);
        if (Input.GetKeyDown(KeyCode.Space) || skillController.skillOnPossible)
        {
            StartCoroutine(TimeCoroutine(0.05f));

            skillController.SkillUsed();

        }
    }
    IEnumerator TimeCoroutine(float time)
    {
        for(int i = 0; i < bulletRemain; i++)
        {
            Instantiate(homingBullet, homingPos, Quaternion.identity);
            yield return new WaitForSeconds(time);
            
        }
        yield return null;
    }

}
