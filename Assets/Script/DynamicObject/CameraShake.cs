using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    GameObject player;
    TpsPlayerMover playerScript;

    public float duration;
    void Start()
    {
        player = GameObject.Find("Player");
        playerScript = player.GetComponent<TpsPlayerMover>();
    }

    // Update is called once per frame
    void Update()
    {
        if(playerScript.collisionImpact > playerScript.collisionImpactLImit)
        {
            StartCoroutine(Shake(playerScript.collisionImpact, duration));
        }
    }

    public IEnumerator Shake(float duration, float magnitude)
    {
        Vector3 originalPosition = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            transform.position = originalPosition + Random.insideUnitSphere * magnitude;
            elapsed += Time.deltaTime;
            yield return null;
        }
        transform.position = originalPosition;
    }
}
