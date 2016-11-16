using UnityEngine;
using System.Collections;

public class FootstepParticles : MonoBehaviour
{
	public GameObject footSplash;
	public GameObject particleTransform;

	public void SpawnParticles()
	{
		if (StaticVars.isGrounded) 
		{
			GameObject temp = Instantiate (footSplash, particleTransform.transform.position, Quaternion.identity) as GameObject;
			Destroy (temp, 1);
		}
	}

}
