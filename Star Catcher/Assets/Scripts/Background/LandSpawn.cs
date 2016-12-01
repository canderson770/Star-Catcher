using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LandSpawn : MonoBehaviour 
{
	Vector3 otherSpawn;
	int randomNum = 0;

	public List<GameObject> moduleList;

	LandList landListScript;

	void Start () 
	{
		GameObject ListGameObject = GameObject.Find ("Lists");
		landListScript = ListGameObject.GetComponent<LandList> ();
		moduleList = new List<GameObject> (landListScript.landModuleList);

		if (gameObject.name.Contains ("landModuleWolfP1")) 
		{
			moduleList.Clear ();
			moduleList.Add (landListScript.wolfP2);
		} 
		else if (gameObject.name.Contains ("landModuleWolfP2")) 
		{
			for (int i = 0; i < moduleList.Count; i++) 
			{
				if(moduleList[i].name == "landModuleWolfP1")
				{
					moduleList.Remove(moduleList[i]);
					break;
				}
			}
		}
		else
		{
			for (int i = 0; i < moduleList.Count; i++) 
			{
			if(moduleList[i].name == gameObject.name.Replace("(Clone)", ""))
				{
					moduleList.Remove(moduleList[i]);
					break;
				}
			}
		}
	}

	void OnTriggerEnter (Collider coll)
	{
		if (coll.gameObject.layer == LayerMask.NameToLayer("Ground Trigger"))
		{
			randomNum = Random.Range (0, moduleList.Count);
			otherSpawn = new Vector3 (45, 0, 0) + transform.position;
			Instantiate (moduleList [randomNum], otherSpawn, Quaternion.identity);
		}
	}
}
