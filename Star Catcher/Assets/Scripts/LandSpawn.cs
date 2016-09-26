using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandSpawn : MonoBehaviour 
{
	public Vector3 spawnPoint;
	public List<GameObject> landModules;
	public int lastModule = 1;
	public int randomNum = 0;


	void OnTriggerEnter ()
	{
		print ("hit");
//		randomNum = Random.Range (0, landModules.Count - 1);
//
//		while (randomNum == lastModule)
//		{
//			print ("same");
//			randomNum = Random.Range (0, landModules.Count - 1);
//		}
//		
		Instantiate (landModules [Random.Range (0, landModules.Count - 1)], spawnPoint, Quaternion.identity);

//		lastModule = randomNum;
	}
	
	void OnTriggerExit () 
	{
		print ("delete");
		Destroy (gameObject);
	}
}
