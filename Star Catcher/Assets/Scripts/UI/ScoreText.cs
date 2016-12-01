using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour 
{
	Text scoreText;
	float time;


	void Start()
	{
		scoreText = GetComponent<Text> ();
	}

	void Update()
	{
		time = Time.timeSinceLevelLoad;
		StaticVars.score = (int)time + StaticVars.starCount * 10;
		scoreText.text = StaticVars.score.ToString().PadLeft(6, '0');
	}
}
