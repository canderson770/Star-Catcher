using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FinalScoreText : MonoBehaviour 
{
	Text scoreText;

	void Start()
	{
		scoreText = GetComponent<Text> ();
	}

	void Update()
	{
		scoreText.text = StaticVars.score.ToString().PadLeft(6, '0');
	}
}
