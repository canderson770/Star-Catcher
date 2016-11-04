using UnityEngine;
using System.Collections;

public class WolfControl : MonoBehaviour 
{
	Rigidbody wolfRb;
	float speedModifier;

	public float wolfSpeed = 15;

	void Start () 
	{
		wolfRb = GetComponent<Rigidbody> ();
		speedModifier = Random.Range (10, 20);

		if(StaticVars.randomNegPos == -1)
			wolfRb.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);

		wolfRb.AddForce (new Vector3 (-StaticVars.randomNegPos * (wolfSpeed + speedModifier), 0, 0), ForceMode.VelocityChange);
		Destroy (gameObject, 5);
	}
}
