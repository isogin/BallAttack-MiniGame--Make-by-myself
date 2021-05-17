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
            if (StatusModelSinglton.Instance.playerWin == 2 && StatusModelSinglton.Instance.sceneChange)
            {

                Invoke("NextScene", 3);


                StatusModelSinglton.Instance.sceneChange = false;
            }
            if (StatusModelSinglton.Instance.enemyWin == 2)
            {
                
                

            }
        }

        void NextScene()
        {
            //シーンを切り替える
            StatusModelSinglton.Instance.NextScene();
        }
    }
}


