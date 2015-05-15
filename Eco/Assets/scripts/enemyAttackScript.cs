using UnityEngine;
using System.Collections;

public class enemyAttackScript : MonoBehaviour {

	public float enemyAttackPower = 25f; 
	
	private UIControlScript hpScript;
	public GameObject playerHP;

	void Awake()
	{
		//gets UIscript
		hpScript = playerHP.GetComponent<UIControlScript>();
		
	}

	// Use this for initialization
	void Start () {


	
	}

	void FixedUpdate()
	{

		
	}
	
	// Update is called once per frame
	void Update () {


	
	}
	//takes hp away from the player
	void OnTriggerEnter2D(Collider2D otherObject)
	{
		
		if(otherObject.gameObject.tag == "Player")
		{

			hpScript.Hp = hpScript.Hp - enemyAttackPower;
			
		}
		
	}

}
