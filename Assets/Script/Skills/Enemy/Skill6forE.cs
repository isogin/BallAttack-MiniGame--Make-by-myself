using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill6forE : MonoBehaviour
{
    Vector3 homingPos;
    public GameObject homingBullet;

    public float bulletRemain;

    public float timeOut;
    public float timeElapsed;

    public bool skillFinish = true;
    private void Start()
    {

    }
    private void Update()
    {

        timeElapsed += Time.deltaTime;
        homingPos = new Vector3(this.gameObject.transform.position.x, this.gameObject.transform.position.y + 2, this.gameObject.transform.position.z);
        if (timeElapsed > timeOut && skillFinish)
        {
            StartCoroutine(TimeCoroutine(0.05f));
            timeElapsed = 0;
            skillFinish = false;
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
