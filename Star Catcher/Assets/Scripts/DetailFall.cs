using UnityEngine;
using System.Collections;

public class DetailFall : MonoBehaviour 
{
	Rigidbody detailRb;

	void Start () 
	{
		detailRb = GetComponent<Rigidbody> ();
	}
	
	void OnCollisionEnter(Collision coll)
	{
		if (coll.gameObject.layer == 8) 
		{
//			detailRb.isKinematic = true;
			transform.parent = coll.gameObject.transform;
		}
	}


	void OnTriggerExit () 
	{
		Destroy (gameObject);
	}
}
