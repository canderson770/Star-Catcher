using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetailSpawner : MonoBehaviour 
{
	public List<GameObject> spawnpoints;
	DetailListScript detailScript;

	float chance;


	void Start () 
	{
		GameObject detailScriptGameObject = GameObject.Find ("Lists");
		detailScript = detailScriptGameObject.GetComponent<DetailListScript> ();

//		for(int i = 0; i > transform.childCount; i++)
//		{
//			GameObject child = transform.GetChild (i).gameObject;
//
//			if (child.name == "DetailSpawn")
//			{
//				print (child);
//				spawnpoints.Add(child);
//			}
//
//		}
		chance = 100 - detailScript.chanceToSpawn;


		foreach(GameObject sp in spawnpoints)
		{
			bool onOff = (Random.value > chance/100);
			if (onOff)
			{
				GameObject go;
				int randomNum = Random.Range (0, detailScript.details.Count);
				if (detailScript.details[randomNum].layer == LayerMask.NameToLayer("Non Interactables"))
					go = Instantiate (detailScript.details[randomNum], sp.transform.position, Quaternion.identity) as GameObject;
				else
					go = Instantiate (detailScript.details[randomNum], sp.transform.position, sp.transform.rotation) as GameObject;

				go.transform.SetParent (transform);
			}
		}
	}
}
