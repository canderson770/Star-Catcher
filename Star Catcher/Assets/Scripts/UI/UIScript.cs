using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class UIScript : MonoBehaviour
{
	Scene scene;

	public GameObject pausedPanel;

	void Start()
	{
		scene = SceneManager.GetActiveScene ();
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape))
			Pause ();

		if (StaticVars.isPaused) 
		{
			Time.timeScale = 0;

			if (!StaticVars.gameOver)
				pausedPanel.SetActive (true);
		}
		else
		{
			Time.timeScale = 1;
			pausedPanel.SetActive (false);
		}	
	}

	public void Pause()
	{
		StaticVars.isPaused = !StaticVars.isPaused;
	}

	public void Restart()
	{
		StaticVars.Reset ();
		SceneManager.LoadScene (scene.name);
	}

	public void MainMenu()
	{
		SceneManager.LoadScene ("Main Menu");
	}

	public void Quit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif

		Application.Quit();
	}
}
