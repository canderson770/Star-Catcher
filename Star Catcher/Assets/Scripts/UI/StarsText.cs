using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarsText : MonoBehaviour 
{
	Text starText;

	void Start()
	{
		starText = GetComponent<Text> ();
	}

	void Update()
	{
		starText.text = "Stars: " + StaticVars.starCount.ToString ();
	}
}
