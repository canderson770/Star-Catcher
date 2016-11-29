using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DetailSpawner : MonoBehaviour 
{
	public List<GameObject> spawnpoints;
	DetailListScript detailScript;

	void Start () 
	{
		GameObject detailScriptGameObject = GameObject.Find ("DetailList");
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

		foreach(GameObject sp in spawnpoints)
		{
			bool onOff = (Random.value > detailScript.chanceToSpawn/100);
			if (onOff)
			{
				int randomNum = Random.Range (0, detailScript.details.Count);
				if (detailScript.details[randomNum].layer == LayerMask.NameToLayer("Non Interactables"))
					Instantiate (detailScript.details[randomNum], sp.transform.position, Quaternion.identity);
				else
					Instantiate (detailScript.details[randomNum], sp.transform.position, sp.transform.rotation);
			}
		}
	}
}
