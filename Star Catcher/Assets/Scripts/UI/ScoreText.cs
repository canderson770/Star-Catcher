using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreText : MonoBehaviour 
{
	Text scoreText;
	float distance;

	public GameObject cam;

	void Start()
	{
		scoreText = GetComponent<Text> ();
	}

	void Update()
	{
		distance = cam.transform.position.x / 10;
		StaticVars.score = (int)distance + StaticVars.starCount * 50;
		scoreText.text = "Score: " + StaticVars.score.ToString().PadLeft(6, '0');
	}
}
