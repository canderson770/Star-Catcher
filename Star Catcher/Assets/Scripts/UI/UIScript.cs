﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{

	public void Pause()
	{
		StaticVars.isPaused = !StaticVars.isPaused;
	}

	public void Restart()
	{
		StaticVars.Reset ();
		SceneManager.LoadScene (2);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene (1);
		StaticVars.isPaused = false;
	}

	public void Quit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif

		Application.Quit();
	}
}