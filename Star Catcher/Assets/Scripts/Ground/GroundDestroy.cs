using UnityEngine;
using System.Collections;

public class GroundDestroy : MonoBehaviour 
{
	void OnTriggerExit (Collider coll) 
	{
		if(coll.gameObject.layer == 9 /*GroundTrigger*/)
			Destroy (gameObject);
	}
}
