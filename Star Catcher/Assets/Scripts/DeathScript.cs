using UnityEngine;
using System.Collections;

public class DeathScript : MonoBehaviour 
{
	public Vector3 defaultSpawn;
	Rigidbody character;

	void Start()
	{
		character = GetComponent<Rigidbody> ();	
	}

	void OnTriggerEnter()
	{
		Death ();
	}

	void Death()
	{
		character.velocity = new Vector3 (0, 0, 0);
		transform.position = defaultSpawn;
	}
}
