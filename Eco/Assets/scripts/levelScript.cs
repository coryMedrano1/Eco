using UnityEngine;
using System.Collections;

public class levelScript : MonoBehaviour {

	public Transform respawnPosition;

	// Use this for initialization
	void Start () {
		//find respawn point
		respawnPosition.transform.position = GameObject.FindWithTag("Respawn").transform.position;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherObject)
	{

		if(otherObject.gameObject.tag == "Player")
		{

			otherObject.gameObject.transform.position = respawnPosition.transform.position;

		}

	}
}
