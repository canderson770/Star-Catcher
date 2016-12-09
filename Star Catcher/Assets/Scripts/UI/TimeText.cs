using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeText : MonoBehaviour 
{
	Text timeText;
	float timeMin;
	float timeSec;
	string otherText;
	Pause pauseScript;

	void Start()
	{
		timeText = GetComponent<Text> ();
		pauseScript = GameObject.Find ("Canvas").GetComponent<Pause> ();
	}

	void FixedUpdate()
	{
		StaticVars.time -= Time.deltaTime;
		otherText = string.Format("{0:0}:{1:00}", Mathf.Floor(StaticVars.time/60), Mathf.Floor(StaticVars.time % 60));
		timeText.text = "Time: " + otherText;

		if (Mathf.Floor(StaticVars.time) <= 0)
			pauseScript.GameOver ();
	}
}
