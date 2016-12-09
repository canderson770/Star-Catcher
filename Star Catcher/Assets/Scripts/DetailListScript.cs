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

	void Awake()
	{
		print ("===================" + StaticVars.currentDifficulty + "===================");

		if (StaticVars.currentDifficulty == StaticVars.Difficulty.Easy) 
		{
			RemoveLoop (details, "DeathObstacles");
			RemoveLoop (safeDetails, "DeathObstacles");
		} 
		else if (StaticVars.currentDifficulty == StaticVars.Difficulty.Normal) 
		{
			RemoveLoop (safeDetails, "DeathObstacles");
		}
		else if (StaticVars.currentDifficulty == StaticVars.Difficulty.Unfair)
		{
			RemoveLoopExcept (details, "DeathObstacles");
			RemoveLoopExcept (safeDetails, "DeathObstacles");
			chanceForSafe = 40;
			chanceToSpawn = 40;
		}					
	}
		
	void RemoveLoop(List<GameObject> _list, string _layer)
	{
		for (int i = 0; i < _list.Count; i++) 
		{
//			print (i.ToString() + " out of " + _list.Count.ToString());
			if (_list [i].layer == LayerMask.NameToLayer (_layer))
			{
//				print ("Removed: " + _list [i].name);
				_list.RemoveAt (i);

				if (i != _list.Count - 1)
					i = -1;
			} 
		}
	}

	void RemoveLoopExcept(List<GameObject> _list, string _layer)
	{
		for (int i = 0; i < _list.Count; i++) 
		{
//			print (i.ToString() + " out of " + _list.Count.ToString());
//			print (_list [i].name);
			if(_list[i].layer != LayerMask.NameToLayer(_layer))
			{
//				print ("Removed: " + _list [i].name);
				_list.RemoveAt (i);

				if (i != _list.Count - 1)
					i = -1;
			}
		}
	}
}
