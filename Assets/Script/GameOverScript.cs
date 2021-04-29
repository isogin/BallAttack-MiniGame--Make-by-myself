using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverScript : SingletonMonoBehaviour<GameOverScript>
{
    public float restartTime;

     GameObject resultText;
     GameObject playerText;
     GameObject enemyText;

    public GameObject GameRestartBotton;
     GameObject player;
     GameObject enemy;

    public Text playerScore;
    public Text enemyScore;
    public Text result;

    // Start is called before the first frame update
    void Start()
    {


        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");

        playerScore = playerText.GetComponent<Text>();
        enemyScore = enemyText.GetComponent<Text>();
        result = resultText.GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        if(StatusModelSinglton.Instance.enemyWin == 1)
        {
            enemyScore.text = "〇";
        }
        if(StatusModelSinglton.Instance.playerWin == 1)
        {
            playerScore.text = "〇";
        }
        if(StatusModelSinglton.Instance.enemyWin == 2)
        {
            enemyScore.text = "〇〇";
            result.text = "Game Over!!";
            GameRestartBotton.SetActive(true);
        }
        if(StatusModelSinglton.Instance.playerWin == 2)
        {
            playerScore.text = "〇〇";
            result.text = "Game Clear!!";
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "PlayerBall")
        {
            StatusModelSinglton.Instance.OnEnemyRoundWin();
            Debug.Log($"roundFinish ,playerPoint{StatusModelSinglton.Instance.playerWin}");
            Debug.Log($"roundFinish ,enemyPoint{StatusModelSinglton.Instance.enemyWin}");
            StartCoroutine("Restart");


        }
        if(other.gameObject.tag == "enemyBall")
        {
            StatusModelSinglton.Instance.OnPlayerRoundWin();
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
