using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageHanicum : MonoBehaviour
{
    public GameObject[] Train;


    public float destroyTime;
    float elapsedTime;
    int number;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        //一定時間経過したら
        if (elapsedTime > destroyTime)
        {
            elapsedTime = 0f;
            for (int i = 0; i < 4; i++)
            {
                number = Random.Range(0, Train.Length);
                Train[number].SetActive(false);
                StartCoroutine(Resurrection(number));
                Debug.Log("hit");
            }
        }

    }
    IEnumerator Resurrection(int number)
    {
        yield return new WaitForSeconds(destroyTime / 2);
        elapsedTime = 0f;
        yield return new WaitForSeconds(destroyTime / 2);
        Train[number].SetActive(true);
        elapsedTime = 0f;
    }
}
