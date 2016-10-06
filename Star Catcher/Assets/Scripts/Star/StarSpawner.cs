using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarSpawner : MonoBehaviour
{
	public List<Transform> spawnPoints;
	public GameObject star;
	public float spawnSeconds = 1f;

	void Start()
	{
//		spawnPoints = new List<Transform> ();
//		SetAsSpawnPoint.PassSpawnPointTransform += AddToSpawnPointsList;

		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn()
	{
		while (!StaticVars.isPaused)
		{
			yield return new WaitForSeconds (3);

			Instantiate (star, spawnPoints [Random.Range (0, spawnPoints.Count)].position, Quaternion.identity);

			yield return new WaitForSeconds (spawnSeconds);
		}
	}

	void AddToSpawnPointsList(Transform _spawnPoint)
	{
		spawnPoints.Add (_spawnPoint);
	}
}