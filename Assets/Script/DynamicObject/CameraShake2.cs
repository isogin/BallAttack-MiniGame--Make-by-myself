using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake2 : MonoBehaviour
{
    GameObject player;
    BallController playerScript;
    public float impactIndex;
    public float duration;

    bool shake = true;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        if((playerScript.collisionImpactLimit < playerScript.collisionImpact) && shake)
        {
            Shake(playerScript.collisionImpact * 0.8f, duration);
            playerScript.collisionImpact = 0f;
            StartCoroutine("ShakeSet");
            shake = false;

        }
    }

    public void Shake(float Impact, float duration)
    {

        iTween.ShakePosition(this.gameObject, iTween.Hash("x", Impact * impactIndex, "y", Impact * impactIndex, "time", duration));
    }

    IEnumerator ShakeSet()
    {
        yield return new WaitForSeconds(1f);
        shake = true;
    }
}
