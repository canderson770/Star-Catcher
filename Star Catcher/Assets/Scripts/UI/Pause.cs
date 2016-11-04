using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour 
{
	public GameObject pausedPanel;
	public GameObject HUD;
	public GameObject deathPanel;

	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator> ();
	}


	void Update ()
	{
		if (Input.GetButtonDown("Cancel") && !StaticVars.gameOver)
			StaticVars.isPaused = !StaticVars.isPaused;

		if (StaticVars.isPaused) 
		{
			Time.timeScale = 0;

			if (!StaticVars.gameOver) 
			{
				pausedPanel.SetActive (true);
				HUD.SetActive (false);
			} 
			else 
			{
				deathPanel.SetActive (true);
				HUD.SetActive (false);
			}
		}
		else
		{
			Time.timeScale = 1;
			pausedPanel.SetActive (false);
			HUD.SetActive (true);
		}

		anim.SetBool ("Pause", StaticVars.isPaused);
	}
}
