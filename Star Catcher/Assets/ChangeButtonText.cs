using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ChangeButtonText : MonoBehaviour
{
	Text buttonText;

	void Start ()
	{
		buttonText = GetComponent<Text> ();
	}

	void Update()
	{
		if (StaticVars.gameOver == true)
			buttonText.text = "Retry";
		else
			buttonText.text = "Resume";
	}
}
