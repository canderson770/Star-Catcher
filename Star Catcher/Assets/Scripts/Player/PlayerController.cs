using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	//Private Variables
	Rigidbody rabbitRB;
	SpriteRenderer rabbitSprite;
	Animator anim;
	AudioSource audio;
	bool hasDoubleJump = false;
	bool canMove = true;

	//Public Variables
	public float speed = 5;
	public float jumpSpeed = 400;
	public float gravity = 10;


	void Start()
	{
		rabbitRB = GetComponent<Rigidbody> ();
		rabbitSprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		audio = GetComponent<AudioSource> ();

		StaticVars.speed = speed;
	}

	void Update()
	{
		if (!StaticVars.isPaused)
		{
			anim.SetBool ("isGrounded", StaticVars.isGrounded);

			if (StaticVars.isGrounded)
				hasDoubleJump = true;
		
			Move (Input.GetAxis ("Horizontal"));

			if (Input.GetButtonDown ("Jump"))
				Jump ();

			Gravity ();
		}


		if (StaticVars.isPaused)
			audio.Pause();
		else
			audio.UnPause();
	}

	void OnCollisionStay(Collision coll)
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer ("WallCollider")) 
		{
			canMove = false;
		}
	}

	void OnCollisionExit(Collision coll)
	{
		if(coll.gameObject.layer == LayerMask.NameToLayer("WallCollider"))
			canMove = true;
	}

	void Move(float _moveInput)
	{
		if (canMove) 
		{
			rabbitRB.velocity = new Vector3 (_moveInput * StaticVars.speed, rabbitRB.velocity.y, 0);

			anim.SetFloat ("Speed", Mathf.Abs (_moveInput));

			if (_moveInput < 0) 
			{
				transform.rotation = Quaternion.Euler (0, 180, 0);
			} 
			else if (_moveInput > 0)
			{
				transform.rotation = Quaternion.Euler (0, 0, 0);
			}
		}
}

	void Gravity()
	{
		if (rabbitRB.velocity.y < .1)
			rabbitRB.AddForce (Vector3.down * gravity, ForceMode.Acceleration);
	}

	void Jump()
	{
		StaticVars.speed = speed;
		if (StaticVars.isGrounded || hasDoubleJump) 
		{
			if (!StaticVars.isGrounded && hasDoubleJump)
				hasDoubleJump = false;
			
			upJump ();
			anim.PlayInFixedTime ("rabbit_jumpSquat");
		}
	}

	public void upJump()
	{
		rabbitRB.velocity = new Vector3 (rabbitRB.velocity.x, 0, 0);
		rabbitRB.AddForce (Vector3.up * jumpSpeed, ForceMode.VelocityChange);
	}
}