using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverScript : MonoBehaviour
{
    public float restartTime;

    bool isEnd = false;
     GameObject resultText;
     GameObject playerText;
     GameObject enemyText;
    public float playerPoint;
    public float enemyPoint;

     GameObject player;
     GameObject enemy;

     Vector3 firstPlayerPos;
     Vector3 firstEnemyPos;
    // Start is called before the first frame update
    void Start()
    {
        resultText = GameObject.Find("GameResultText");
        enemyText = GameObject.Find("EnemyPoint");
        playerText = GameObject.Find("PlayerPoint");
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");

        firstEnemyPos = enemy.transform.position;
        firstPlayerPos = player.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(playerPoint == 1)
        {
            this.playerText.GetComponent<Text>().text = "〇";
        }
        if (enemyPoint == 1)
        {
            this.enemyText.GetComponent<Text>().text = "〇";
        }
        if(playerPoint == 2)
        {
            resultText.GetComponent<Text>().text = "Game Clear!!";
        }
        if(enemyPoint == 2)
        {
            resultText.GetComponent<Text>().text = "Game Over!!";
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "PlayerBall")
        {
            enemyPoint++;
            this.isEnd = true;

            StartCoroutine("Restart");


        }
        if(other.gameObject.tag == "enemyBall")
        {
            playerPoint++;
            this.isEnd = true;

            StartCoroutine("Restart");
        }
      
    }
    IEnumerator Restart()
    {
        Destroy(enemy);
        Destroy(player);

        yield return new WaitForSeconds(restartTime);

        Application.LoadLevel("Stage 4");
    }
}
