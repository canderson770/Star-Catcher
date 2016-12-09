using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class PlayerCollisionsPrefabs
{
	public GameObject wolf;
	public GameObject loseSeconds;
}

public class PlayerCollisons : MonoBehaviour 
{
	public PlayerCollisionsPrefabs Prefabs;

	//Private Variables
	Rigidbody rabbitRB;
	Animator anim;
	UIBar uiBar;
	bool isInvincible;
	int wolfDistance = 60;
	int loseStarAmount;
	float savedSpeed;

	Pause pauseScript;

	//Public Variables
	public float invinciblitySeconds = 3;
	public int secondsToLose = 10;

	void Start()
	{
		rabbitRB = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
		pauseScript = GameObject.Find ("Canvas").GetComponent<Pause> ();

		if (Prefabs.wolf == null)
			print ("PlayerCollisions: No wolf prefab");
		if(Prefabs.loseSeconds == null)
			print("PlayerCollisions: No loseSeconds prefab");

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
				StaticVars.randomNegPos = (UnityEngine.Random.Range (0, 2) * 2) - 1;

				if (StaticVars.randomNegPos == -1)
					wolfDistance = 30;
				else
					wolfDistance = 50;
				
				Instantiate (Prefabs.wolf, coll.transform.parent.transform.position + new Vector3 (wolfDistance * StaticVars.randomNegPos, 5.4f, 0),
					Prefabs.wolf.transform.rotation);
				Destroy (coll.gameObject);
			}
		}

		if (coll.gameObject.layer == LayerMask.NameToLayer("DeathZone"))
			pauseScript.GameOver ();
	}	
		
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
		
		Instantiate(Prefabs.loseSeconds, rabbitRB.transform.position, Quaternion.identity);

		StaticVars.starBarCount = 0;
		uiBar.UpdateBar ();


		isInvincible = true;
		anim.SetBool ("isInvincible", isInvincible);
		StartCoroutine (InvincibleFrames ());
	}

	IEnumerator InvincibleFrames()
	{
		yield return new WaitForSeconds (invinciblitySeconds);

		isInvincible = false;
		anim.SetBool ("isInvincible", isInvincible);
	}
}