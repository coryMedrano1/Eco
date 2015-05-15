using UnityEngine;
using System.Collections;

public class enemyScript3 : MonoBehaviour {
	
	public float enemyHP = 10f; 
	public Transform target;
	public float enemySpeed = 3f;
	
	Transform enemyTransform;
	public bool isActive = false; 
	
	bool facingRight = false;
	
	// Use this for initialization
	void Start () {
		
		enemyTransform = transform;
		
	}
	
	void FixedUpdate()
	{
		
		if (isActive == true)
		{
			//get direction from target
			Vector3 direction = target.position - enemyTransform.position;
			//give direction a magnetude
			direction.Normalize();
			//move in direction of target
			enemyTransform.position += direction * enemySpeed * Time.deltaTime;
			
		}
		
		if(enemyHP <= 0)
		{
			Destroy(gameObject);
			
		}
		
		float enemyDirection = target.position.x - enemyTransform.position.x;
		
		if (enemyDirection > 0 && !facingRight)
			Flip ();
		else if (enemyDirection < 0 && facingRight)
			Flip ();
		
	}
	
	// Update is called once per frame
	void Update () {
		
		
		
	}
	
	void OnTriggerEnter2D(Collider2D otherObject)
	{
		
		if(otherObject.gameObject.tag == "Player")
		{
			
			isActive = true;
			
		}
		
	}
	
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
