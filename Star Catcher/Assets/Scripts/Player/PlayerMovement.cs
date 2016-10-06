using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
	public float speed = 5;
	public float jumpSpeed = 400;
	public float jumpMax = 2;
	float jumpAmount = 2;


	Rigidbody character;
	SpriteRenderer rabbitSprite;
	Animator anim;
	SphereCollider sphereColl;


	void Start()
	{
		character = GetComponent<Rigidbody> ();
		rabbitSprite = GetComponent<SpriteRenderer> ();
		anim = GetComponent<Animator> ();
		sphereColl = GetComponent<SphereCollider> ();
	}

	void Update()
	{
		Move (Input.GetAxis ("Horizontal"));

		if (Input.GetKeyUp(KeyCode.Space))
			Jump ();
	}

	void Move(float _moveInput)
	{
		character.transform.Translate(_moveInput * speed * Time.deltaTime, 0, 0);

		if (_moveInput == 0)
			anim.SetBool ("isMoving", false);
		else
			anim.SetBool ("isMoving", true);

		if (_moveInput < 0) 
		{
			rabbitSprite.flipX = true;
			sphereColl.center = new Vector3 (-1.5f, .5f, 0);
		}
		if (_moveInput > 0)
		{
			rabbitSprite.flipX = false;
			sphereColl.center = new Vector3 (1.5f, .5f, 0);
		}
	}

	void Jump()
	{
		
		if (jumpAmount-- > 0) 
		{
			character.velocity = new Vector3 (character.velocity.x, 0, 0);
			anim.PlayInFixedTime ("rabbit_jumpSquat");
			character.AddForce (Vector3.up * jumpSpeed, ForceMode.Impulse);
		}
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.layer == 8) 
		{
			jumpAmount = jumpMax;
			anim.SetBool ("isGrounded", true);
//			print ("grounded");
		}
	}

	void OnCollisionExit(Collision coll)
	{
		if (coll.gameObject.layer == 8) 
		{
//			jumpAmount = 1;
			anim.SetBool ("isGrounded", false);
//			print ("not grounded");
		}
	}
}