using UnityEngine;
using System.Collections;

public class Grounded : MonoBehaviour
{
	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}

	void OnCollisionStay(Collision coll)
		{
			if (coll.gameObject.layer == 8) 
			{
				anim.SetBool ("isGrounded", true);
	
			}
		}
	
		void OnCollisionExit(Collision coll)
		{
			if (coll.gameObject.layer == 8) 
			{
				anim.SetBool ("isGrounded", false);
	
			}
		}
}
