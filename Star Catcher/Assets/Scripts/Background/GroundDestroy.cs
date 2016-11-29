using UnityEngine;
using System.Collections;

public class GroundDestroy : MonoBehaviour 
{
	void OnTriggerExit (Collider coll) 
	{
		if(coll.gameObject.layer == LayerMask.NameToLayer("Ground Trigger"))
			Destroy (gameObject);
	}
}
