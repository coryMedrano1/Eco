using UnityEngine;
using System.Collections;

public class energyScript : MonoBehaviour {

	private UIControlScript hpScript;
	public GameObject playerHP;

	public AudioClip health;

	// Use this for initialization
	void Start () {

		hpScript = playerHP.GetComponent<UIControlScript>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other)
	{

		if(other.gameObject.tag == "Player")
		{
			audio.PlayOneShot(health);

			hpScript.Hp = hpScript.Hp + 10f;

			Destroy (gameObject);
			
		}

	}
}
