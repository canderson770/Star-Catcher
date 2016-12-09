using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DifficultyText : MonoBehaviour 
{
	Text diffText;

	void Awake()
	{
		diffText = GetComponent<Text> ();
//		diffText.text = StaticVars.currentDifficulty.ToString();
	}

	void OnEnable () 
	{
		diffText.text = StaticVars.currentDifficulty.ToString();
	}
}
