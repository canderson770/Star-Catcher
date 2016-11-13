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
		wolfRb = GetComponent<Rigidbody> ();
		speedModifier = Random.Range (10, 20);

		if (StaticVars.randomNegPos == -1)
			speedModifier += 10;
		else
			speedModifier -= 7;
		
		if(StaticVars.randomNegPos == -1)
			wolfRb.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);

		Destroy (gameObject, 5);
	}

	void Update()
	{
		wolfRb.velocity = Vector3.zero;
		wolfRb.AddForce (new Vector3 (-StaticVars.randomNegPos * (wolfSpeed + speedModifier), 0, 0), ForceMode.VelocityChange);
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
