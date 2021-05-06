using UnityEngine;
using System.Collections;

public class DWGColliderEnabler : MonoBehaviour {

	Vector3 firstPos;
	void Start () {
		if(gameObject.GetComponent<Collider>()){ // If this game object has a collider, continue
			gameObject.GetComponent<Collider>().enabled = true; // Enable the collider
			Destroy(GetComponent<DWGColliderEnabler>()); // Remove this script from the game object
		}
		firstPos = transform.position;
	}
    private void Update()
    {
        if(transform.position != firstPos)
        {
			Invoke("Terminate", 5f);
			Debug.Log("hit");
        }
    }

	void Terminate()
    {
		Destroy(this.gameObject);
    }
}
