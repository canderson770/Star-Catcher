using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour 
{
	Scene scene;
	Rigidbody rabbitRB;

	public GameObject star;

	void Start()
	{
		scene = SceneManager.GetActiveScene ();
		rabbitRB = GetComponent<Rigidbody> ();
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.layer == 11) 
		{
			Death ();
		}
	}	

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.layer == 18)  
		{
			if (StaticVars.starCount > 0) 
			{
				Hit ();
			}
			else
				Death ();
		}
	}

	void Hit()
	{
		print ("hit");
		rabbitRB.velocity = new Vector3 (rabbitRB.velocity.x, 0, 0);
		rabbitRB.AddForce (new Vector3 (Random.Range(-10,10), 15, 0), ForceMode.Impulse);

		for(int i = 0; i < (StaticVars.starCount - StaticVars.starCount/2); i++)
			Instantiate (star, transform.position, Quaternion.identity);

		StaticVars.starCount = StaticVars.starCount/2;
	}

	void Death()
	{
		SceneManager.LoadScene (scene.name);
		StaticVars.Reset ();
	}
}