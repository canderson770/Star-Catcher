using UnityEngine;
using System.Collections;

public class FootstepParticles : MonoBehaviour
{
	public GameObject footSplash;

	Transform particleTransform;

	void Start()
	{
		particleTransform = transform.Find ("particlesSpawnPoint");
	}

	public void SpawnParticles()
	{
		if (StaticVars.isGrounded) 
		{
			GameObject temp = Instantiate (footSplash, particleTransform.position, Quaternion.identity) as GameObject;
			Destroy (temp, 1);
		}
	}

}
