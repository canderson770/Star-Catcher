using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Pause : MonoBehaviour 
{
	public EventSystem myEventSystem;

	public GameObject pausedPanel;
	public GameObject HUD;

	ChangeButtonText changeBtn;
	FinalScoreText finalScore;

	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator> ();

		GameObject resumeBtn = GameObject.Find ("Resume");
		changeBtn = resumeBtn.GetComponent<ChangeButtonText> ();

		GameObject finalScoreText = GameObject.Find ("PauseScore");
		finalScore = finalScoreText.GetComponent<FinalScoreText> ();
	}


	void Update ()
	{
		if (Input.GetButtonDown("Cancel") && !StaticVars.gameOver)
			StaticVars.isPaused = !StaticVars.isPaused;

		changeBtn.ChangeText ();

		if (StaticVars.isPaused) 
		{
			Time.timeScale = 0;
			pausedPanel.SetActive (true);
			HUD.SetActive (false);
			finalScore.UpdateScore ();
		}
		else
		{
			Time.timeScale = 1;
			pausedPanel.SetActive (false);
			HUD.SetActive (true);
			myEventSystem.SetSelectedGameObject(null);
		}

		anim.SetBool ("Pause", StaticVars.isPaused);
	}
}
