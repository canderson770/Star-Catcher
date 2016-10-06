using UnityEngine;
using System.Collections;

public class StarCatch : MonoBehaviour 
{

	void OnTriggerEnter (Collider coll) 
	{
		if (coll.gameObject.layer == 15)
		{
			Destroy (coll.gameObject.transform.parent.gameObject);
			StaticVars.starCount++; 
			print ("Stars: " + StaticVars.starCount);
		}	
	}
}
