using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownText : MonoBehaviour 
{
	Text timeText;

	void Start()
	{
		timeText = GetComponent<Text> ();
	}

	void Update()
	{
		if (Mathf.Floor (StaticVars.time) == 3) 
		{
			timeText.text = "3";
			print (3);
		}
		else if (Mathf.Floor (StaticVars.time) == 2) 
		{
			timeText.text = "2";
			print (2);
		}
		else if (Mathf.Floor (StaticVars.time) == 1) 
		{
			timeText.text = "1";
			print (1);
		}
		else
			timeText.text = "";
	}
}
