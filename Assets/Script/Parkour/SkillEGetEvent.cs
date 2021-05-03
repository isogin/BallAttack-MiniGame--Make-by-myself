using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SkillEGetEvent : MonoBehaviour
{
    GameObject player;
    ParkourAcceleration skill;
    public GameObject key;

    public GameObject Text;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        skill = player.GetComponent<ParkourAcceleration>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        key.SetActive(true);
        //テキストを出す
        Text.SetActive(true);
        //スキルを使えるようにする
        skill.enabled = true;
        //破壊する
        Destroy(this.gameObject);
    }
}
