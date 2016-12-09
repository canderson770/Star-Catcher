using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class InputName : MonoBehaviour 
{
	Leaderboard leaderboardScript;
	GameObject seletedObj;

	void Start()
	{
		leaderboardScript = GameObject.Find ("Canvas").GetComponent<Leaderboard> ();
	}

	void Update ()
	{
		if (EventSystem.current.currentSelectedGameObject == null)
			EventSystem.current.SetSelectedGameObject (seletedObj);
		seletedObj = EventSystem.current.currentSelectedGameObject;

		if (EventSystem.current.currentSelectedGameObject == leaderboardScript.inputField) 
		{
			if (Input.GetKeyDown(KeyCode.DownArrow))
			{
				EventSystem.current.SetSelectedGameObject (leaderboardScript.doneBtn);
			} 
			else if (Input.GetButtonUp ("Submit")) 
			{
				leaderboardScript.SetHighScore ();
			}
		} 
		else if (EventSystem.current.currentSelectedGameObject == leaderboardScript.doneBtn) 
		{
			if (Input.GetKeyDown(KeyCode.UpArrow)) 
			{
				EventSystem.current.SetSelectedGameObject (leaderboardScript.inputField);
			} 
		}

	}
}
