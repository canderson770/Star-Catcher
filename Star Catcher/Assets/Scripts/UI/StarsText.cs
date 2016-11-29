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

	public void UpdateStars()
	{
		starText.text = StaticVars.starCount.ToString ();
	}
}
