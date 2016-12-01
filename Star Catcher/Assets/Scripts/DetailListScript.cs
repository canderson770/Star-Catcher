using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetailListScript : MonoBehaviour 
{
	public List<GameObject> details;

	public List<GameObject> safeDetails;

	[Tooltip("Percent chance to spawn all details")]
	[Range(0,100)]
	public float chanceToSpawn = 50;

	[Tooltip("Percent chance to spawn non-iteractable details")]
	[Range(0,100)]
	public float chanceForSafe = 50;

	void Start()
	{
		chanceToSpawn = 100 - chanceToSpawn;

		chanceForSafe = 100 - chanceForSafe;
	}
}
