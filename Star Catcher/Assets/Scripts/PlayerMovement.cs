using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{

	Rigidbody character;
	public float speed = 5;
	public float jumpSpeed = 400;
	public float jumpMax = 2;
	float jumpAmount = 2;

	void Start()
	{
		character = GetComponent<Rigidbody> ();
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
	}

	void Jump()
	{
		if (jumpAmount-- > 0) 
		{
			character.velocity = new Vector3 (character.velocity.x, 0, 0);
			character.AddForce (Vector3.up * jumpSpeed, ForceMode.Impulse);
		}
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.layer == 8) 
		{
			jumpAmount = jumpMax;
			print ("Grounded");
		}
	}
}