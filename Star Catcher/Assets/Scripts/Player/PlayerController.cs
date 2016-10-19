using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
	public float speed = 5;
	public float jumpSpeed = 400;
	public float jumpMax = 2;
	float jumpAmount = 2;

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
		Move (Input.GetAxis ("Horizontal"));

		if (Input.GetKeyUp(KeyCode.Space))
			Jump ();
	}

	void Move(float _moveInput)
	{
 		character.velocity = new Vector3(_moveInput * speed, character.velocity.y, 0);

		anim.SetFloat ("Speed", Mathf.Abs(_moveInput));

		if (_moveInput < 0) 
		{
			rabbitSprite.flipX = true;
		}
		if (_moveInput > 0)
		{
			rabbitSprite.flipX = false;
		}
	}

	void Jump()
	{
		if (jumpAmount-- > 0) 
		{
			anim.PlayInFixedTime ("rabbit_jumpSquat");
		}
	}

	public void upJump()
	{
		character.velocity = new Vector3 (character.velocity.x, 0, 0);
		character.AddForce (Vector3.up * jumpSpeed, ForceMode.VelocityChange);
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.layer == 8) 
		{
//			print ("grounded");
			jumpAmount = jumpMax;
			anim.SetBool ("isGrounded", true);

		}
	}

	void OnCollisionExit(Collision coll)
	{
		if (coll.gameObject.layer == 8) 
		{
//			print ("not grounded");
			anim.SetBool ("isGrounded", false);

		}
	}
}