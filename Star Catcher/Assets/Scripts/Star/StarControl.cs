using UnityEngine;
using System.Collections;

public class StarControl : MonoBehaviour 
{
	Rigidbody starRB;
	float randomDir;

	public GameObject starSplash;

	public float force = 100;
	public float lifetime = 3;
	public float upForce;
	public float zforce;

	void Start()
	{
		starRB = GetComponent<Rigidbody> ();

		randomDir = Random.value;
		if (randomDir > .5f)
			randomDir = 1;
		else
			randomDir = -1;
		
		starRB.AddForce (new Vector3(Random.Range(force/2, force) * randomDir, upForce, zforce), ForceMode.VelocityChange);

		Destroy (gameObject, lifetime);
	}

	void OnCollisionEnter(Collision coll)
	{
		if (starSplash != null)
		{
			if (coll.gameObject.layer == 8 /*Ground*/) 
			{
				gameObject.layer = 17 /*StarBoundaryOff*/;
				foreach (ContactPoint contact in coll)
				{
					GameObject temp = Instantiate (starSplash, contact.point + Vector3.up / 5, Quaternion.identity) as GameObject;
					Destroy (temp, 1);
				}
			}
		}
	}

}
