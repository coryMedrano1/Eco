using UnityEngine;
using System.Collections;

public class attackScript : MonoBehaviour {

	public float playerAttackPower = 25f;

	Animator attacks;
	bool isAttacking = false;

	private characterControllerScript characterScript;
	public GameObject character;

	private enemyAIScript enemyScript1;
	private enemyScript2 enemyScript2;
	private enemyScript3 enemyScript3;
	private enemyScript4 enemyScript4;
	private enemyScript5 enemyScript5;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public GameObject enemy4;
	public GameObject enemy5;
	
	public AudioClip swordSoundEffect;

	void Awake()
	{
		//gets the player script
		characterScript = character.GetComponent<characterControllerScript>();
		//gets all enemies scripts
		enemyScript1 = enemy1.GetComponent<enemyAIScript>();
		enemyScript2 = enemy2.GetComponent<enemyScript2>();
		enemyScript3 = enemy3.GetComponent<enemyScript3>();
		enemyScript4 = enemy4.GetComponent<enemyScript4>();
		enemyScript5 = enemy5.GetComponent<enemyScript5>();

	}

	// Use this for initialization
	void Start () {
		//gets and assigns the animator to attacks 
		attacks = GetComponent<Animator>();

	}

	void FixedUpdate()
	{
		//connects the animator with the script bool
		attacks.SetBool("attack", isAttacking);

	}
	
	// Update is called once per frame
	void Update () {
		//sets up keys for the attack and plays the animation and sound effects
		if(isAttacking == false && Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
		{
			attacks.SetBool("attack", true);

			collider2D.enabled = true;

			audio.PlayOneShot(swordSoundEffect);

		}

		else
		{
			collider2D.enabled = false;

		}
	
	}
	//code to do damage on enemy
	void OnTriggerEnter2D(Collider2D otherObject)
	{
		
		if(otherObject.gameObject.tag == "enemy1")
		{

			enemyScript1.enemyHP = enemyScript1.enemyHP - playerAttackPower;
			
		}

		if(otherObject.gameObject.tag == "enemy2")
		{
			
			enemyScript2.enemyHP = enemyScript2.enemyHP - playerAttackPower;
			
		}

		if(otherObject.gameObject.tag == "enemy3")
		{
			
			enemyScript3.enemyHP = enemyScript3.enemyHP - playerAttackPower;
			
		}

		if(otherObject.gameObject.tag == "enemy4")
		{
			
			enemyScript4.enemyHP = enemyScript4.enemyHP - playerAttackPower;
			
		}

		if(otherObject.gameObject.tag == "enemy5")
		{
			
			enemyScript5.enemyHP = enemyScript5.enemyHP - playerAttackPower;
			
		}
		
	}



}
