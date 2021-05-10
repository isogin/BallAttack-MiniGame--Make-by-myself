using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClone : MonoBehaviour
{
    GameObject enemy;
    bool finishTrace = true;
    Rigidbody rb;
    public float enemySpeed;

    public float lifeTime;
    public GameObject skillControllObject;
    SkillController skillController;
    bool onGround;
    void Start()
    {
        skillControllObject = GameObject.Find("SkillController");
        skillController = skillControllObject.GetComponent<SkillController>();

        enemy = GameObject.Find("Enemy");
        rb = GetComponent<Rigidbody>();
        Invoke("TraceFinish", lifeTime / 2);
        Invoke("Destroy", lifeTime);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 trace = (enemy.transform.position - this.gameObject.transform.position).normalized;
        if (finishTrace && onGround)
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

    private void OnCollisionExit(Collision collision)
    {
        onGround = false;
    }

    private void OnCollisionStay(Collision collision)
    {
        onGround = true;
    }
}
