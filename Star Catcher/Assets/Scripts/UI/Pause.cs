using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Pause : MonoBehaviour 
{
	public GameObject pausedPanel;
	public GameObject HUD;

	ChangeButtonText changeBtn;
	FinalScoreText finalScore;
	Leaderboard leaderboardScript;

	Animator anim;
	GameObject seletedObj;
	GameObject resumeButton;

	void Start()
	{
		anim = GetComponent<Animator> ();
		resumeButton = GameObject.Find ("ResumeButton");

		changeBtn = GameObject.Find ("Resume").GetComponent<ChangeButtonText> ();
		finalScore = GameObject.Find ("PauseScore").GetComponent<FinalScoreText> ();
		leaderboardScript = GetComponent<Leaderboard> ();

		UpdateUI();
	}

	void Update ()
	{
		if (Input.GetButtonDown ("Cancel") && !StaticVars.gameOver)
		{
			StaticVars.isPaused = !StaticVars.isPaused;
			UpdateUI ();
		}

		if (StaticVars.isPaused) 
		{
			Time.timeScale = 0;

			if (EventSystem.current.currentSelectedGameObject == null)
				EventSystem.current.SetSelectedGameObject (seletedObj);
			seletedObj = EventSystem.current.currentSelectedGameObject;
		}
		else
			Time.timeScale = 1;
	}

	public void UpdateUI()
	{
		if (StaticVars.isPaused) 
		{
			changeBtn.ChangeText ();
			pausedPanel.SetActive (true);
			HUD.SetActive (false);
			finalScore.UpdateScore ();
			EventSystem.current.SetSelectedGameObject(null);
		}
		else
		{
			pausedPanel.SetActive (false);
			HUD.SetActive (true);
			EventSystem.current.SetSelectedGameObject(null);
		}

		anim.SetBool ("Pause", StaticVars.isPaused);
	}

	public void GameOver()
	{
		StaticVars.gameOver = true;
		StaticVars.isPaused = true;
		UpdateUI();

		int totalStars = StaticVars.starCount + PlayerPrefs.GetInt ("TotalStars", 0);
		PlayerPrefs.SetInt("TotalStars", totalStars);

		leaderboardScript.CheckForHighScore ();
//		StartCoroutine (WaitToCheckScore ());
	}	

	IEnumerator WaitToCheckScore()
	{
		yield return new WaitForSeconds (1);
		print ("check");
		leaderboardScript.CheckForHighScore ();

	}
}
