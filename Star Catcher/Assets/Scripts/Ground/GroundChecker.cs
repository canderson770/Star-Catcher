using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour
{
	void OnTriggerExit (Collider coll) 
	{
		if (coll.gameObject.layer == 21 /*GroundCheck*/)
			StaticVars.isGrounded = false;
	}

	void OnTriggerStay(Collider coll)
	{
		if (coll.gameObject.layer == 21 /*GroundCheck*/)
			StaticVars.isGrounded = true;
	}
}
