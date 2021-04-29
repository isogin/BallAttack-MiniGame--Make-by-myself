using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallAttack
{
    public class SceneManager : SingletonMonoBehaviour<SceneManager>
    {
        // Start is called before the first frame update
        void Start()
        {
            DontDestroyOnLoad(Instance);
        }

        // Update is called once per frame
        void Update()
        {
            if (StatusModelSinglton.Instance.playerWin == 2)
            {
                //プレイヤーの勝利  点数をリセットする
                StatusModelSinglton.Instance.GamePointReset();

                //シーンを切り替える
                StatusModelSinglton.Instance.NextScene();
            }
            if (StatusModelSinglton.Instance.enemyWin == 2)
            {
                //エネミーの勝利 点数をリセットする
                StatusModelSinglton.Instance.GamePointReset();

            }
        }
    }
}


