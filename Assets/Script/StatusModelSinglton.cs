﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class StatusModelSinglton : SingletonMonoBehaviour<StatusModelSinglton>
{
 //プレイヤーの勝ち数
    public int playerWin { get; private set; } //ほかのスクリプトから値を取得できるが、変更できない
    //エネミーの勝ち数
    public int enemyWin { get; private set; }

    public bool sceneChange;
    // Start is called before the first f{rame update
    private void Awake()
    {
        playerWin = 0;
        enemyWin = 0;
        sceneChange = true;
    }
    void Start()
    {
        DontDestroyOnLoad(Instance);
    }

    // Update is called once per frame
    void Update()
    {

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
        StartCoroutine("SceneStep");

    }

    IEnumerator SceneStep()
    {
        GamePointReset();
        
        yield return new WaitForSeconds(3.0f);
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        sceneChange = true;
        
    }

}
