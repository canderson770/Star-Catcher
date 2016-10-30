using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeText : MonoBehaviour 
{
	Text timeText;
	float timeMin;
	float timeSec;
	string otherText;

	public Text countdown;
	public Canvas canvas;

	void Start()
	{
		timeText = GetComponent<Text> ();
	}

	void FixedUpdate()
	{
		StaticVars.time -= Time.deltaTime;
		otherText = string.Format("{0:0}:{1:00}", Mathf.Floor(StaticVars.time/60), Mathf.Floor(StaticVars.time % 60));
		timeText.text = "Time: " + otherText;

		if (Mathf.Floor(StaticVars.time) <= 0)
			StaticVars.GameOver ();
	}
}
