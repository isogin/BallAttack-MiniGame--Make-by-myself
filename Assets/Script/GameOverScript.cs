using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverScript : SingletonMonoBehaviour<GameOverScript>
{
    public float restartTime;

    bool isEnd = false;
     GameObject resultText;
     GameObject playerText;
     GameObject enemyText;


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


    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "PlayerBall")
        {
            StatusModelSinglton.Instance.OnEnemyRoundWin();
            this.isEnd = true;
            Debug.Log($"roundFinish ,playerPoint{StatusModelSinglton.Instance.playerWin}");
            Debug.Log($"roundFinish ,enemyPoint{StatusModelSinglton.Instance.enemyWin}");
            StartCoroutine("Restart");


        }
        if(other.gameObject.tag == "enemyBall")
        {
            StatusModelSinglton.Instance.OnPlayerRoundWin();
            this.isEnd = true;
            Debug.Log($"roundFinish ,enemyPoint{StatusModelSinglton.Instance.enemyWin}");
            Debug.Log($"roundFinish ,playerPoint{StatusModelSinglton.Instance.playerWin}");
            StartCoroutine("Restart");
        }
      
    }
    IEnumerator Restart()
    {
        enemy.transform.position = new Vector3(100, 100, 100);
        player.transform.position = new Vector3(105, 105, 105);


        yield return new WaitForSeconds(restartTime);

        player.transform.position = new Vector3(0, 3, 0);
        enemy.transform.position = new Vector3(1, 3, 1);
    }
}
