using UnityEngine;
using System.Collections;

public class PlayerCollisons : MonoBehaviour 
{
	Rigidbody rabbitRB;
	Animator anim;

	public GameObject fakeStar;
	public GameObject wolf;
	public GameObject deathPanel;

	void Start()
	{
		rabbitRB = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.layer == 11 /*DeathZone*/) 
			Death ();

		else if (coll.gameObject.layer == 20 /*Wolf*/)
			Hit ();

		else if (coll.gameObject.layer == 19 /*Wolf Trigger*/) 
		{
			Instantiate (wolf, coll.transform.parent.transform.position + new Vector3(45, 5.4f,0), wolf.transform.rotation);
			Destroy (coll.gameObject);
		}
	}	

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.layer == 18 /*DeathObstacles*/)  
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
		rabbitRB.velocity = new Vector3 (rabbitRB.velocity.x, 0, 0);
		rabbitRB.AddForce (new Vector3 (Random.Range(-10,10), 15, 0), ForceMode.Impulse);

		for(int i = 0; i < (StaticVars.starCount /*- StaticVars.starCount/2*/); i++)
			Instantiate (fakeStar, transform.position, Quaternion.identity);

		anim.Play ("rabbit_hit");
		StaticVars.starCount = 0;
	}

	void Death()
	{
		StaticVars.gameOver = true;
		StaticVars.isPaused = true;
		deathPanel.SetActive (true);
	}
}