using UnityEngine;
using System.Collections;

public class PlayerCollisons : MonoBehaviour 
{
	Rigidbody rabbitRB;
	Animator anim;
	bool isInvincible;
	int wolfDistance = 60;
	int loseStarAmount;
	float savedSpeed;

	UIBar uiBar;

	public GameObject wolf;
	public GameObject secondsText;

	public float invincibleSec = 3;
	public int secondsToLose = 10;
	public float slowDown = 2;

	void Start()
	{
		rabbitRB = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();

		GameObject uiBarGameObject = GameObject.Find ("Full Bar");
		uiBar = uiBarGameObject.GetComponent<UIBar> ();
	}

	void OnTriggerEnter(Collider coll)
	{
		if (!isInvincible) 
		{
			if (coll.gameObject.layer == LayerMask.NameToLayer("Wolf"))
				Hit ();
			else if (coll.gameObject.layer == LayerMask.NameToLayer("WolfSpawnTrigger"))
			{
				StaticVars.randomNegPos = (Random.Range (0, 2) * 2) - 1;

				if (StaticVars.randomNegPos == -1)
					wolfDistance = 30;
				else
					wolfDistance = 50;
				
				Instantiate (wolf, coll.transform.parent.transform.position + new Vector3 (wolfDistance * StaticVars.randomNegPos, 5.4f, 0), wolf.transform.rotation);
				Destroy (coll.gameObject);
			}
		}

		if (coll.gameObject.layer == LayerMask.NameToLayer("DeathZone"))
			StaticVars.GameOver ();


//		if (coll.gameObject.layer == 24 /*Sagebrush*/)
//		{
//			savedSpeed = StaticVars.speed;
//			StaticVars.speed = StaticVars.speed / slowDown;
//		}
	}	

//	void OnTriggerExit(Collider coll)
//	{
//		if (coll.gameObject.layer == 24 /*Sagebrush*/)
//		{
//			StaticVars.speed = savedSpeed;
//		}
//	}

	void OnCollisionStay(Collision coll)
	{
		if (!isInvincible)
		{
			if (coll.gameObject.layer == LayerMask.NameToLayer("DeathObstacles")) 
			{
				Hit ();
			}
		}
	}

	void Hit()
	{
		rabbitRB.velocity = new Vector3 (rabbitRB.velocity.x, 0, 0);
		rabbitRB.AddForce (new Vector3 (0, 25, 0), ForceMode.Impulse);

		anim.PlayInFixedTime("rabbit_hit");

		if (StaticVars.time >= secondsToLose)
			StaticVars.time-= secondsToLose;
		else
			StaticVars.time = 0;

		Instantiate(secondsText, rabbitRB.transform.position, Quaternion.identity);

		StaticVars.starBarCount = 0;
		uiBar.UpdateBar ();


		isInvincible = true;
		anim.SetBool ("isInvincible", isInvincible);
		StartCoroutine (InvincibleFrames ());
	}

	IEnumerator InvincibleFrames()
	{
		yield return new WaitForSeconds (invincibleSec);

		isInvincible = false;
		anim.SetBool ("isInvincible", isInvincible);
	}
}