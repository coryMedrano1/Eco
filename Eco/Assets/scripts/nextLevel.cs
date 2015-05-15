using UnityEngine;
using System.Collections;

public class nextLevel : MonoBehaviour {

	public string levelNumber;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D otherObject)
	{
		//loads the next level
		Application.LoadLevel(levelNumber);
	}

}
