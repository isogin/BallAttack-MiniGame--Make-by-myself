using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusModelSinglton : SingletonMonoBehaviour<StatusModelSinglton>
{
    //プレイヤーの勝ち数
    public int playerWin { get; private set; } //ほかのスクリプトから値を取得できるが、変更葉できない
    //エネミーの勝ち数
    public int enemyWin { get; private set; }
    // Start is called before the first f{rame update
    private void Awake()
    {
        playerWin = 0;
        enemyWin = 0;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (playerWin == 1)
        {

        }
        if (enemyWin == 1)
        {

        }
        if (playerWin == 2)
        {
            //プレイヤーの勝利  点数をリセットする
            GamePointReset();

            //シーンを切り替える
            NextScene();
        }
        if (enemyWin == 2)
        {
            //エネミーの勝利 点数をリセットする
            GamePointReset();
            //シーンを切り替える
            NextScene();
        }
    }

    public void OnPlayerRoundWin()
    {
        playerWin++;
        
    }
    public void OnEnemyRoundWin()
    {
        enemyWin++;
        
    }

    public void GamePointReset()
    {
        playerWin = 0;
        enemyWin = 0;
    }

    public void NextScene()
    {
        Debug.Log("シーンが切り替わりました");
    }
}
