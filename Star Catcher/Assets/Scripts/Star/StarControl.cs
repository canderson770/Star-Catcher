using UnityEngine;
using System.Collections;

public class StarControl : MonoBehaviour 
{
	Rigidbody starRB;
	float randomDir;

	public float force = 100;
	public float lifetime = 3;

	void Start()
	{
		starRB = GetComponent<Rigidbody> ();

		randomDir = Random.value;
		if (randomDir > .5f)
			randomDir = 1;
		else
			randomDir = -1;
		
		starRB.AddForce (new Vector3(Random.Range(force/2, force) * randomDir, 0, 0), ForceMode.VelocityChange);

		WaitToDestroy ();
	}

	IEnumerator WaitToDestroy()
	{
		yield return new WaitForSeconds (lifetime);
		print ("destroy");
		Destroy (gameObject);
	}

	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.layer == 8) 
		{
			gameObject.layer = 17 /*StarBoundaryOff*/;
		}
	}

}
