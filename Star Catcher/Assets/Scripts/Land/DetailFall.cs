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
			WaitForKinematic ();

			if(gameObject.layer == 0)
				gameObject.layer = coll.gameObject.layer;

			detailRb.isKinematic = true;

//			transform.parent = coll.gameObject.transform;
		}
	}


	IEnumerator WaitForKinematic()
	{
		yield return new WaitForSeconds (4);
//		detailRb.isKinematic = true;
	}

	void OnTriggerExit () 
	{
		Destroy (gameObject);
	}
}
