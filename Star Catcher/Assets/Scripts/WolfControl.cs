using UnityEngine;
using System.Collections;

public class WolfControl : MonoBehaviour 
{
	Rigidbody wolfRb;
	float speedModifier;

	public GameObject wolfCollider;
	public float wolfSpeed = 15;

	void Start () 
	{
		if (StaticVars.currentDifficulty == StaticVars.Difficulty.Easy) 
		{
			wolfSpeed -= 5;
		} 
		else if (StaticVars.currentDifficulty == StaticVars.Difficulty.Unfair)
		{
			wolfSpeed += 10;
		}

		wolfRb = GetComponent<Rigidbody> ();
		speedModifier = Random.Range (20, 25);

		if (StaticVars.randomNegPos == -1)
			speedModifier += 10;
		else
			speedModifier -= 0;
		
		if(StaticVars.randomNegPos == -1)
			wolfRb.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);

		Destroy (gameObject, 3);
	}

	void Update()
	{
		wolfRb.velocity = Vector3.zero;
		wolfRb.AddForce (new Vector3 (-StaticVars.randomNegPos * (wolfSpeed + speedModifier), -10, 0), ForceMode.VelocityChange);
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.layer == 19) 
		{
			wolfRb.useGravity = true;
			wolfCollider.SetActive (true);
		}
	}
}
