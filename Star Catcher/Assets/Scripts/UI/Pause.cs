using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class Pause : MonoBehaviour 
{
	EventSystem myEventSystem;

	public GameObject pausedPanel;
	public GameObject HUD;
	public GameObject firstButton;

	Animator anim;

	void Start()
	{
		anim = GetComponent<Animator> ();
//		StartCoroutine (HighlightButton ());
	}


	void Update ()
	{
		if (Input.GetButtonDown("Cancel") && !StaticVars.gameOver)
			StaticVars.isPaused = !StaticVars.isPaused;

		if (StaticVars.isPaused) 
		{
			Time.timeScale = 0;
			Cursor.visible = true;

			if (!StaticVars.gameOver) 
			{
				pausedPanel.SetActive (true);
				HUD.SetActive (false);
			} 
			else 
			{
				pausedPanel.SetActive (true);
				HUD.SetActive (false);
			}
		}
		else
		{
			Time.timeScale = 1;
			pausedPanel.SetActive (false);
			HUD.SetActive (true);
			Cursor.visible = false;
		}

		anim.SetBool ("Pause", StaticVars.isPaused);
	}

//	IEnumerator HighlightButton()
//	{
//		myEventSystem.SetSelectedGameObject (null);
//		yield return new WaitForEndOfFrame();
//		myEventSystem.SetSelectedGameObject(firstButton);
//	}
}
