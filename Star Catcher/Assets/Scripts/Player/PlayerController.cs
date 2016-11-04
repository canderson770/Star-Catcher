using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 5;
	public float jumpSpeed = 400;
	bool hasDoubleJump = false;
	public LayerMask ground;

	Rigidbody character;
	SpriteRenderer rabbitSprite;
	Animator anim;

	void Start()
	{
		character = GetComponent<Rigidbody> ();
		rabbitSprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
	}

	void Update()
	{
		anim.SetBool ("isGrounded", StaticVars.isGrounded);;

		if (StaticVars.isGrounded)
			hasDoubleJump = true;
		
		Move (Input.GetAxis ("Horizontal"));

		if (Input.GetButtonDown("Jump"))
			Jump ();
	}

	void Move(float _moveInput)
	{
 		character.velocity = new Vector3(_moveInput * speed, character.velocity.y, 0);

		anim.SetFloat ("Speed", Mathf.Abs(_moveInput));

		if (_moveInput < 0) 
		{
			transform.rotation = Quaternion.Euler(0, 180, 0);
		}
		if (_moveInput > 0)
		{
			transform.rotation = Quaternion.Euler(0, 0, 0);
		}
	}

	void Jump()
	{
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
		character.velocity = new Vector3 (character.velocity.x, 0, 0);
		character.AddForce (Vector3.up * jumpSpeed, ForceMode.VelocityChange);
	}
}