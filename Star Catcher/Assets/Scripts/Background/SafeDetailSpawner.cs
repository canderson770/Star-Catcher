using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SafeDetailSpawner : MonoBehaviour 
{
	public List<GameObject> spawnpoints;
	DetailListScript detailScript;

	float chance;

	void Start () 
	{
		GameObject detailScriptGameObject = GameObject.Find ("Lists");
		detailScript = detailScriptGameObject.GetComponent<DetailListScript> ();

		chance = 100 - detailScript.chanceForSafe;

		foreach(GameObject sp in spawnpoints)
		{
			bool onOff = (Random.value > chance/100);
			if (onOff)
			{
				GameObject go;
				int randomNum = Random.Range (0, detailScript.safeDetails.Count);
				if (detailScript.safeDetails[randomNum].layer == LayerMask.NameToLayer("Non Interactables"))
					go = Instantiate (detailScript.safeDetails[randomNum], sp.transform.position, Quaternion.identity) as GameObject;
				else
					go = Instantiate (detailScript.safeDetails[randomNum], sp.transform.position, sp.transform.rotation) as GameObject;

				go.transform.SetParent (transform);
			}
		}
	}
}
