using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetailSpawner : MonoBehaviour 
{
	public List<GameObject> spawnpoints;
	public List<GameObject> details;
	float onOff = 1;
	float number = 1;
	string num;

	void Start () 
	{
		print ("Should have " + spawnpoints.Count);

		foreach(GameObject spawnPoint in spawnpoints)
		{
			num += number++;
			onOff = Random.Range (0, 3);
			if (onOff == 1)
			{
				Instantiate (details[Random.Range (0, details.Count)], spawnPoint.transform.position, Quaternion.identity);
			}
		}

		print (num);
		number = 1;
	}
}
