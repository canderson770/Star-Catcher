using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class StarSpawner : MonoBehaviour
{
	public List<Transform> spawnPoints;
	public GameObject star;
	public float spawnSeconds = 1f;
	public float beginningWait;

	Transform parent;

	void Start()
	{
//		spawnPoints = new List<Transform> ();
//		SetAsSpawnPoint.PassSpawnPointTransform += AddToSpawnPointsList;
		parent = GameObject.Find ("Stars and VFX").transform;

		StartCoroutine (Spawn ());
	}

	IEnumerator Spawn()
	{
		yield return new WaitForSeconds (beginningWait);

		while (!StaticVars.isPaused)
		{
			GameObject go = Instantiate (star, spawnPoints [Random.Range (0, spawnPoints.Count)].position, Quaternion.identity) as GameObject;
			go.transform.SetParent (parent);

			yield return new WaitForSeconds (spawnSeconds);
		}
	}

	void AddToSpawnPointsList(Transform _spawnPoint)
	{
		spawnPoints.Add (_spawnPoint);
	}
}