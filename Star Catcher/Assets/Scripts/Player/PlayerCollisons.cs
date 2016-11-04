using UnityEngine;
using System.Collections;

public class PlayerCollisons : MonoBehaviour 
{
	Rigidbody rabbitRB;
	Animator anim;
	bool isInvincible;

	public GameObject fakeStar;
	public GameObject wolf;

	public float invincibleSec = 3;
	public int loseStars = 5;
	int loseStarAmount;
//	public float downForce = 100;

	void Start()
	{
		rabbitRB = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider coll)
	{
		if (!isInvincible) 
		{
			if (coll.gameObject.layer == 20 /*Wolf*/)
				Hit ();
			else if (coll.gameObject.layer == 19 /*Wolf Trigger*/)
			{
				StaticVars.randomNegPos = Random.Range (0, 1) * 2 - 1; 
				Instantiate (wolf, coll.transform.parent.transform.position + new Vector3 (60 * StaticVars.randomNegPos, 5.4f, 0), wolf.transform.rotation);
				Destroy (coll.gameObject);
			}
		}
		if (coll.gameObject.layer == 11 /*DeathZone*/)
			StaticVars.GameOver ();
	}	

	void OnCollisionEnter(Collision coll)
	{
		if (!isInvincible)
		{
			if (coll.gameObject.layer == 18 /*DeathObstacles*/) 
			{
				Hit ();
			}
		}
	}

	void OnCollisionStay(Collision coll)
	{
		if (!isInvincible)
		{
			if (coll.gameObject.layer == 18 /*DeathObstacles*/) 
			{
				Hit ();
			}
		}
	}

	void Hit()
	{
		if (StaticVars.starCount > 0) 
		{
			rabbitRB.velocity = new Vector3 (rabbitRB.velocity.x, 0, 0);
			rabbitRB.AddForce (new Vector3 (0, 25, 0), ForceMode.Impulse);

			if (StaticVars.starCount >= loseStars)
				loseStarAmount = loseStars;
			else
				loseStarAmount = StaticVars.starCount;
			
			for (int i = 0; i < loseStarAmount; i++)
				Instantiate (fakeStar, transform.position, Quaternion.identity);

			anim.PlayInFixedTime("rabbit_hit");

			if (StaticVars.starCount >= loseStars)
				StaticVars.starCount -= loseStars;
			else
				StaticVars.starCount = 0;
			
			StaticVars.starBarCount = 0;
			isInvincible = true;
			anim.SetBool ("isInvincible", isInvincible);
			StartCoroutine (InvincibleFrames ());
		} 
		else
			StaticVars.GameOver ();

	}

	IEnumerator InvincibleFrames()
	{
		yield return new WaitForSeconds (invincibleSec);

		isInvincible = false;
		anim.SetBool ("isInvincible", isInvincible);
	}
}