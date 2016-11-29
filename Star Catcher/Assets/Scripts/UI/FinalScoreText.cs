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

	public void UpdateScore()
	{
		scoreText.text = StaticVars.score.ToString();
	}
}
