using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverScript : MonoBehaviour
{
    bool isEnd = false;
    public GameObject stateText;
    // Start is called before the first frame update
    void Start()
    {
        stateText = GameObject.Find("GameResultText");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "PlayerBall")
        {
            this.isEnd = true;
            this.stateText.GetComponent<Text>().text = "Game Over";
            Destroy(this.gameObject);

        }
        if(other.gameObject.tag == "enemyBall")
        {
            this.isEnd = true;
            this.stateText.GetComponent<Text>().text = "Game Clear!!";
            Destroy(this.gameObject);
        }
      
    }
}
