using UnityEngine;
using System.Collections;

public class FootstepParticles : MonoBehaviour
{
	//Private Variables
	Transform parent;
	Transform particleTransform;

	//Prefabs
	public GameObject footSplash;

	void Start()
	{
		particleTransform = transform.Find ("particlesSpawnPoint");
		parent = GameObject.Find ("Stars and VFX").transform;
	}

	public void SpawnParticles()
	{
		if (StaticVars.isGrounded) 
		{
			GameObject temp = Instantiate (footSplash, particleTransform.position, Quaternion.identity) as GameObject;
			temp.transform.SetParent (parent);
			Destroy (temp, 1);
		}
	}

}
