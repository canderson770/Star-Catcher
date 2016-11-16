using UnityEngine;
using System.Collections;

public class PlayerCollisons : MonoBehaviour 
{
	Rigidbody rabbitRB;
	Animator anim;
	bool isInvincible;
	int wolfDistance = 60;

	public GameObject fakeStar;
	public GameObject wolf;
	public GameObject secondsText;
	public AudioClip bark;

	public float invincibleSec = 3;
//	public int loseStars = 5;
	public int secondsToLose = 10;
	public float slowDown = 2;

	int loseStarAmount;
	float savedSpeed;

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
				StaticVars.randomNegPos = (Random.Range (0, 2) * 2) - 1;

				if (StaticVars.randomNegPos == -1)
					wolfDistance = 30;
				else
					wolfDistance = 50;
				
				Instantiate (wolf, coll.transform.parent.transform.position + new Vector3 (wolfDistance * StaticVars.randomNegPos, 5.4f, 0), wolf.transform.rotation);
				Destroy (coll.gameObject);
				AudioSource.PlayClipAtPoint(bark, new Vector3 (wolfDistance * StaticVars.randomNegPos, 5.4f, 0), 1);
			}
		}
		if (coll.gameObject.layer == 11 /*DeathZone*/)
			StaticVars.GameOver ();


		if (coll.gameObject.layer == 24 /*Sagebrush*/)
		{
			savedSpeed = StaticVars.speed;
			StaticVars.speed = StaticVars.speed / slowDown;
			print (StaticVars.speed);
			print ("sage");
		}
	}	

	void OnTriggerExit(Collider coll)
	{
		if (coll.gameObject.layer == 24 /*Sagebrush*/)
		{
			StaticVars.speed = savedSpeed;
			print (StaticVars.speed);
			print ("sage");
		}
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
//		if (StaticVars.starCount > 0) 
//		{
			rabbitRB.velocity = new Vector3 (rabbitRB.velocity.x, 0, 0);
			rabbitRB.AddForce (new Vector3 (0, 25, 0), ForceMode.Impulse);

			anim.PlayInFixedTime("rabbit_hit");

//			if (StaticVars.starCount >= loseStars)
//				loseStarAmount = loseStars;
//			else
//				loseStarAmount = StaticVars.starCount;
//			
//			for (int i = 0; i < loseStarAmount; i++)
//				Instantiate (fakeStar, transform.position, Quaternion.identity);
//
//			if (StaticVars.starCount >= loseStars)
//				StaticVars.starCount -= loseStars;
//			else
//				StaticVars.starCount = 0;

			if (StaticVars.time >= secondsToLose)
				StaticVars.time-= secondsToLose;
			else
				StaticVars.time = 0;

			Instantiate(secondsText, rabbitRB.transform.position, Quaternion.identity);

			StaticVars.starBarCount = 0;
			isInvincible = true;
			anim.SetBool ("isInvincible", isInvincible);
			StartCoroutine (InvincibleFrames ());
//		} 
//		else
//			StaticVars.GameOver ();

	}

	IEnumerator InvincibleFrames()
	{
		yield return new WaitForSeconds (invincibleSec);

		isInvincible = false;
		anim.SetBool ("isInvincible", isInvincible);
	}
}