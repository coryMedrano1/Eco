using UnityEngine;
using System.Collections;

public class ecoScript : MonoBehaviour {

	bool facingRight = true;
	Animator anime;
	public float maxSpeed = 10f;

	public bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	public float jumpForce = 700f;

	// Use this for initialization
	void Start () {

		anime = GetComponent<Animator>();
	
	}

	void FixedUpdate()
	{

		float move = Input.GetAxis("Horizontal");
		anime.SetFloat("speed", Mathf.Abs(move));
		rigidbody2D.velocity = new Vector2(move * maxSpeed, rigidbody2D.velocity.y);
		if(move > 0 && !facingRight)
		{

			Flip();
			anime.SetBool("flipped", false);


		}
		else if (move < 0 && facingRight)
		{

			Flip();
			anime.SetBool("flipped", true);


		}

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, whatIsGround);
		anime.SetBool("ground", grounded);
		anime.SetFloat("verticalSpeed", rigidbody2D.velocity.y);
		if(grounded && Input.GetKeyDown(KeyCode.Space))
		{

			anime.SetBool("ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));

		}
		else if(grounded && Input.GetKeyDown(KeyCode.Space))
		{
			
			anime.SetBool("ground", false);
			rigidbody2D.AddForce(new Vector2(0, jumpForce));
			
		}

		if(grounded && Input.GetKeyDown(KeyCode.Space) && move > 0 && !facingRight)
		{
			
			anime.SetBool("attack", true);
			
		}

		if(grounded && Input.GetKeyDown(KeyCode.RightArrow))
		{
			
			anime.SetBool("attack", true);
			
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Flip()
	{

		facingRight = !facingRight;


	}

}
