using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameOverScript : SingletonMonoBehaviour<GameOverScript>
{
    public float restartTime;


    public GameObject GameRestartBotton;
    GameObject player;
    GameObject enemy;
    SpinSkill1forE enemyScript;
   
    public Text playerScore;
    public  Text enemyScore;
    public Text result;
    public Rigidbody rbPlayer;
    public Rigidbody rbEnemy;

    // Start is called before the first frame update

    private void Start()
    {
        player = GameObject.Find("Player");
        enemy = GameObject.Find("Enemy");
        enemyScript = enemy.GetComponent<SpinSkill1forE>();
    }
    // Update is called once per frame
    void Update()
    {


        if (StatusModelSinglton.Instance.enemyWin == 1)
        {
            enemyScore.text = "〇";
        }
        if(StatusModelSinglton.Instance.playerWin == 1)
        {
            playerScore.text = "〇";
        }
        if(StatusModelSinglton.Instance.enemyWin == 2)
        {
            GameRestartBotton.SetActive(true);
            enemyScore.text = "〇〇";
            result.text = "Game Over!!";
            
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

        rbEnemy.velocity = Vector3.zero;
        rbPlayer.velocity = Vector3.zero;
        player.transform.position = new Vector3(-3.5f, 5, 0);
        enemy.transform.position = new Vector3(3.5f, 5, 0);

        enemyScript.percent = 80;
    }
}
