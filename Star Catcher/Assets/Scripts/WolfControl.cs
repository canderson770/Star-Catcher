using UnityEngine;
using System.Collections;

public class WolfControl : MonoBehaviour 
{
	Rigidbody wolfRb;

	public float wolfSpeed = 15;

	void Start () 
	{
		wolfRb = GetComponent<Rigidbody> ();
		wolfRb.AddForce (new Vector3 (-wolfSpeed, 0, 0), ForceMode.VelocityChange);
		Destroy (gameObject, 5);
	}
}
