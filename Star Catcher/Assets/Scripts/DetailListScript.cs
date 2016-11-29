using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetailListScript : MonoBehaviour 
{
	public List<GameObject> details;

	public List<GameObject> safeDetails;

	[Range(0,100)]
	public float chanceToSpawn = 50;

	void Start()
	{
		chanceToSpawn = 100 - chanceToSpawn;
	}
}
