using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetailSpawner : MonoBehaviour 
{
	public List<GameObject> spawnpoints;
	public List<GameObject> details;
	bool onOff = true;
	int randomNum;

	void Start () 
	{
		foreach(GameObject spawnPoint in spawnpoints)
		{
//			onOff = (Random.value > 0.5f);
			if (onOff)
			{
				randomNum = Random.Range (0, details.Count);
				if (details[randomNum].layer == 13)
					Instantiate (details[randomNum], spawnPoint.transform.position, Quaternion.identity);
				else
					Instantiate (details[randomNum], spawnPoint.transform.position, spawnPoint.transform.rotation);
			}
		}

	}
}
