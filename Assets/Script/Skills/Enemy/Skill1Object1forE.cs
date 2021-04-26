using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill1Object1forE : MonoBehaviour
{
    public GameObject particleObject;
    public BallController playerScript;
    GameObject player;
    // Start is called before the first frame update

    //オブジェクトの点滅
    private float nextTime;
    public float interval = 1.0f;
    Renderer renderer;
    public float bulletSpeed;

    public float explosionIndex;
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<BallController>();
        nextTime = Time.time;
        renderer = GetComponent<Renderer>();
    }
    
    // Update is called once per frame
    void Update()
    {
        StartCoroutine("FlashObject");
        // transformを取得
        Transform myTransform = this.transform;
        // 現在の座標からのxyz を1ずつ加算して移動
        myTransform.Translate(0, bulletSpeed * 0.001f, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "PlayerBall")
        {
            Instantiate(particleObject, this.transform.position, Quaternion.identity);
            playerScript.Explosion(this.gameObject.transform.position,explosionIndex);
            Destroy(this.gameObject);


            
        }
    }
    IEnumerator FlashObject()
    {
        yield return new WaitForSeconds(3.5f);

        if (Time.time > nextTime)
        {
            renderer.enabled = !renderer.enabled;

            nextTime += interval;
        }
        yield return new WaitForSeconds(1);

        Destroy(this.gameObject);
    }

}
