using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetailSpawner : MonoBehaviour 
{
	public List<GameObject> spawnpoints;
	public List<GameObject> details;
	bool onOff = true;


	void Start () 
	{
		foreach(GameObject spawnPoint in spawnpoints)
		{
			onOff = (Random.value > 0.5f);
			if (onOff)
			{
				Instantiate (details[Random.Range (0, details.Count)], spawnPoint.transform.position, Quaternion.identity);
			}
		}

	}
}
