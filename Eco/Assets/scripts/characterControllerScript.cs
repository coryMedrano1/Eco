using UnityEngine;
using System.Collections;

public class characterControllerScript : MonoBehaviour
{

		public float maxSpeed = 10f;
		bool facingRight = true;
		Animator anim;
		
		public bool grounded = false;
		public Transform groundCheck;
		float groundRadius = 0.2f;
		public LayerMask whatIsGround;
		public float jumpForce = 700f;

	public AudioClip jump;


		void Start ()
		{
				//gets animator
				anim = GetComponent<Animator> ();
	
		}
	
		// Update is called once per frame
		void FixedUpdate ()
		{
				//checks if player is on ground
				grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
				//sets ground in animator
				anim.SetBool ("ground", grounded);
				//gives vertical speed in animator
				anim.SetFloat ("verticalSpeed", rigidbody2D.velocity.y);

				//gets the input that the player will have to press to move
				float move = Input.GetAxis ("Horizontal");
				//sets speed for movement in animator
				anim.SetFloat ("speed", Mathf.Abs (move));
				//gives velocity to character
				rigidbody2D.velocity = new Vector2 (move * maxSpeed, rigidbody2D.velocity.y);
				
				if (move > 0 && !facingRight)
						Flip ();
				else if (move < 0 && facingRight)
						Flip ();


		}

		void Update ()
		{

				if (grounded && Input.GetKeyDown (KeyCode.Space)) {

			audio.PlayOneShot(jump);
						//sets grounded to false
						anim.SetBool ("ground", false);
						//adding a force to jump
						rigidbody2D.AddForce (new Vector2 (0, jumpForce));

				}

		}

		//flip the character when called
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
