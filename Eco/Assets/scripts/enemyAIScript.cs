using UnityEngine;
using System.Collections;

public class enemyAIScript : MonoBehaviour {

	public float enemyHP = 10f; 
	public Transform target;
	public float enemySpeed = 3f;

	Transform enemyTransform;
	public bool isActive = false; 

	bool facingRight = false;

	// Use this for initialization
	void Start () {
		//defines enemyTransform
		enemyTransform = transform;
	
	}

	void FixedUpdate()
	{
		//enemy movement
		if (isActive == true)
		{
			//get direction from target
			Vector3 direction = target.position - enemyTransform.position;
			//give direction a magnetude
			direction.Normalize();
			//move in direction of target
			enemyTransform.position += direction * enemySpeed * Time.deltaTime;
			
		}
		//enemy death
		if(enemyHP <= 0)
		{
			Destroy(gameObject);
			
		}
		//defining enemyDirection
		float enemyDirection = target.position.x - enemyTransform.position.x;
		//flipping the sprite when going in another direction
		if (enemyDirection > 0 && !facingRight)
			Flip ();
		else if (enemyDirection < 0 && facingRight)
			Flip ();

	}
	
	// Update is called once per frame
	void Update () {


		
	}
	//activates the enemy
	void OnTriggerEnter2D(Collider2D otherObject)
	{

		if(otherObject.gameObject.tag == "Player")
		{

			isActive = true;

		}

	}
	//flip method
	void Flip ()
	{
		
		facingRight = !facingRight;
		//flips character
		Vector3 theScale = transform.localScale;
		
		theScale.x *= -1;
		//defines the theScale
		transform.localScale = theScale;
		
	}

}
