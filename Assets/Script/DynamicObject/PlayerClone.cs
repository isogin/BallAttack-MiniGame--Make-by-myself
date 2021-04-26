using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    GameObject enemy;
    bool finishTrace = true;
    Rigidbody rb;
    public float enemySpeed;

    public GameObject skillControllObject;
    SkillController skillController;
    void Start()
    {
        skillControllObject = GameObject.Find("SkillController");
        skillController = skillControllObject.GetComponent<SkillController>();

        enemy = GameObject.Find("Enemy");
        rb = GetComponent<Rigidbody>();
        Invoke("TraceFinish", 4f);
        Invoke("Destroy", 5.5f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 trace = (enemy.transform.position - this.gameObject.transform.position).normalized;
        if (finishTrace)
        {
            rb.AddForce(trace * enemySpeed);
        }
    }
    void TraceFinish()
    {
        finishTrace = false;
    }
    private void Destroy()
    {
        Destroy(this.gameObject);
        skillController.SkillUsed();
    }
}
