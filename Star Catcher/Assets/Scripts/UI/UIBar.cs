using UnityEngine;
using System.Collections;

public class UIBar : MonoBehaviour 
{
	RectTransform rectT;
	public int secondsToAdd = 10;

	void Start () 
	{
		rectT = GetComponent<RectTransform> ();
	}
	
	void Update () 
	{
		rectT.sizeDelta = new Vector2 (StaticVars.starBarCount * 20, 6.5f);

		if (StaticVars.starBarCount >= 10) 
		{
			StaticVars.time += secondsToAdd;
			StaticVars.starBarCount = 0;
		}
	}
}
