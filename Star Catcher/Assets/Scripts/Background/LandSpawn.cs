using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandSpawn : MonoBehaviour 
{
	Vector3 otherSpawn;
	public List<GameObject> landModules;
	int randomNum = 0;

	void OnTriggerEnter (Collider coll)
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer("Ground Trigger"))
		{
			randomNum = Random.Range (0, landModules.Count);
			otherSpawn = new Vector3 (45, 0, 0) + transform.position;
			Instantiate (landModules [randomNum], otherSpawn, Quaternion.identity);
		}
	}
}
