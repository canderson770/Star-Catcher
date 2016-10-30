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

	void Start()
	{
		rabbitRB = GetComponent<Rigidbody> ();
		anim = GetComponent<Animator> ();
	}

	void OnTriggerEnter(Collider coll)
	{
		if (!isInvincible) {
			if (coll.gameObject.layer == 11 /*DeathZone*/)
				StaticVars.GameOver ();
			else if (coll.gameObject.layer == 20 /*Wolf*/)
				Hit ();
			else if (coll.gameObject.layer == 19 /*Wolf Trigger*/) {
				Instantiate (wolf, coll.transform.parent.transform.position + new Vector3 (45, 5.4f, 0), wolf.transform.rotation);
				Destroy (coll.gameObject);
			}
		}
	}	

	void OnCollisionEnter(Collision coll)
	{
		if (!isInvincible) {
			if (coll.gameObject.layer == 18 /*DeathObstacles*/) {
				Hit ();
			}
		}
	}

	void Hit()
	{
		if (StaticVars.starCount > 0) {
			rabbitRB.velocity = new Vector3 (rabbitRB.velocity.x, 0, 0);
			rabbitRB.AddForce (new Vector3 (Random.Range (-10, 10), 15, 0), ForceMode.Impulse);

			for (int i = 0; i < (StaticVars.starCount /*- StaticVars.starCount/2*/); i++)
				Instantiate (fakeStar, transform.position, Quaternion.identity);

			anim.Play ("rabbit_hit");
			StaticVars.starCount = 0;
//			isInvincible = true;
		} else
			StaticVars.GameOver ();

	}

//	IEnumerator InvincibleFrames()
//	{
//		yield return new WaitForSeconds (invincibleSec);
//
//		isInvincible = false;
//	}
}