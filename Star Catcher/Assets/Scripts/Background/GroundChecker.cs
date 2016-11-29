using UnityEngine;
using System.Collections;

public class GroundChecker : MonoBehaviour
{
	void OnTriggerExit (Collider coll) 
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer("Ground Check"))
			StaticVars.isGrounded = false;
	}

	void OnTriggerStay(Collider coll)
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer("Ground Check"))
			StaticVars.isGrounded = true;
	}
}
