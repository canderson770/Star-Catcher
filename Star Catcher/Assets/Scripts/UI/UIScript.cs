using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
	public float levelTime = 120;

	DifficultyText diffTextScript;
	Leaderboard leaderboardScript;
	Pause pauseScript;

	Animator anim;

	GameObject title;
	GameObject buttons;
	GameObject star;

	GameObject difficultyMenu;
	GameObject highScoreMenu;
	GameObject confirmMenu;
	GameObject optionMenu;

	GameObject easyDifficulty;
	GameObject normalDifficulty;
	GameObject unfairDifficulty;
	GameObject selectedGlow;

	GameObject difficultyButton;
	GameObject lastButton;
	GameObject subLastButton;

	void Awake()
	{
		switch(PlayerPrefs.GetString ("difficulty", "Normal"))
		{ 
		case "Easy":
			{
				StaticVars.currentDifficulty = StaticVars.Difficulty.Easy; break;
			}
		case "Normal":
			{
				StaticVars.currentDifficulty = StaticVars.Difficulty.Normal; break;
			}
		case "Unfair":
			{
				StaticVars.currentDifficulty = StaticVars.Difficulty.Unfair; break;
			}
		default:
			{
				StaticVars.currentDifficulty = StaticVars.Difficulty.Normal; break;
			}
		}

		StaticVars.time = levelTime;
	
		leaderboardScript = GetComponent<Leaderboard> ();

		if (SceneManager.GetActiveScene ().name == "Main Menu")
		{
			anim = GetComponent<Animator> ();

			title = GameObject.Find ("Title");
			buttons = GameObject.Find ("Buttons");
			star = GameObject.Find ("Star");

			difficultyMenu = GameObject.Find ("DifficultyPanel");
			highScoreMenu = GameObject.Find ("HighScorePanel");
			confirmMenu = GameObject.Find ("ConfirmText");
			optionMenu = GameObject.Find ("OptionsPanel");

			easyDifficulty = GameObject.Find ("EasyButton");	
			normalDifficulty = GameObject.Find ("NormalButton");
			unfairDifficulty = GameObject.Find ("UnfairButton");
			selectedGlow = GameObject.Find ("SelectedImage");

			difficultyButton = GameObject.Find ("Difficulty");
			subLastButton = difficultyButton;


			diffTextScript = GameObject.Find ("DifficultyText").GetComponent<DifficultyText> ();
		} 
		else if (SceneManager.GetActiveScene ().buildIndex == 2)
			pauseScript = GameObject.Find ("Canvas").GetComponent<Pause> ();
	}

	void Start()
	{
		if (SceneManager.GetActiveScene ().name == "Main Menu") 
		{
			difficultyMenu.SetActive (false);
			highScoreMenu.SetActive (false);
			confirmMenu.SetActive (false);
			optionMenu.SetActive (false);
		} 
	}
		
	public void FirstButton()
	{
		if(StaticVars.gameOver == true)
			Restart();
		else
			Pause();
	}

	public void Pause()
	{
		StaticVars.isPaused = false;
		pauseScript.UpdateUI ();
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

	public void DifficultyMenu()
	{
		subLastButton = EventSystem.current.currentSelectedGameObject;
		SetMainActive (false, "Difficulty");

		switch(StaticVars.currentDifficulty)
		{ 
		case StaticVars.Difficulty.Easy:
			{
				selectedGlow.transform.position = easyDifficulty.transform.position;
				EventSystem.current.SetSelectedGameObject (easyDifficulty); break;
			}
			case StaticVars.Difficulty.Normal:
			{
				selectedGlow.transform.position = normalDifficulty.transform.position;
				EventSystem.current.SetSelectedGameObject (normalDifficulty); break;
			}
			case StaticVars.Difficulty.Unfair:
			{
				selectedGlow.transform.position = unfairDifficulty.transform.position;
				EventSystem.current.SetSelectedGameObject (unfairDifficulty); break;
			}
			default:
			{
				selectedGlow.transform.position = normalDifficulty.transform.position;
				EventSystem.current.SetSelectedGameObject (normalDifficulty); break;
			}
		}
	}
		
	public void Leaderboard()
	{
		lastButton = EventSystem.current.currentSelectedGameObject;
		SetMainActive (false, "Leaderboard");

		EventSystem.current.SetSelectedGameObject (GameObject.Find("Back"));
		leaderboardScript.UpdateText ();
	}

	public void Option()
	{
		if (GameObject.Find ("Options") != null)
			lastButton = EventSystem.current.currentSelectedGameObject;
		
		SetMainActive (false, "Option");
		EventSystem.current.SetSelectedGameObject (GameObject.Find(subLastButton.name));
	}

	public void Confirm()
	{
		subLastButton = EventSystem.current.currentSelectedGameObject;
		SetMainActive (false, "Confirm");
		EventSystem.current.SetSelectedGameObject(GameObject.Find("Cancel"));
	}

	public void Delete()
	{
		leaderboardScript.DeleteAllData ();
		Option ();
	}

	public void Back()
	{
		SetMainActive (true, "");
	}

	public void Quit()
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif
		Application.Quit();
	}

//==============================================================================================================

	public void Easy()
	{
		StaticVars.currentDifficulty = StaticVars.Difficulty.Easy;
		selectedGlow.transform.position = easyDifficulty.transform.position;
		PlayerPrefs.SetString ("difficulty", "Easy");
	}

	public void Normal()
	{
		StaticVars.currentDifficulty = StaticVars.Difficulty.Normal;
		selectedGlow.transform.position = normalDifficulty.transform.position;
		PlayerPrefs.SetString ("difficulty", "Normal");
	}

	public void Unfair()
	{
		StaticVars.currentDifficulty = StaticVars.Difficulty.Unfair;
		selectedGlow.transform.position = unfairDifficulty.transform.position;
		PlayerPrefs.SetString ("difficulty", "Unfair");
	}

//==============================================================================================================

	IEnumerator Wait(GameObject _button)
	{
		yield return new WaitForEndOfFrame ();
		yield return new WaitForEndOfFrame ();
		print (_button);
		EventSystem.current.SetSelectedGameObject (_button);
	}

	void SetMainActive(bool _bool, string _submenu)
	{
		optionMenu.SetActive (_bool);
		
		if (_submenu == "Difficulty")
			difficultyMenu.SetActive (!_bool);
		else if (_submenu == "Leaderboard")
			highScoreMenu.SetActive (!_bool);
		else if (_submenu == "Confirm")
			confirmMenu.SetActive (!_bool);
		else if (_submenu == "Option") 
		{
			optionMenu.SetActive (!_bool);
			difficultyMenu.SetActive (_bool);
			confirmMenu.SetActive (_bool);
		}
		else 
		{
			difficultyMenu.SetActive (!_bool);
			highScoreMenu.SetActive (!_bool);
			confirmMenu.SetActive (!_bool);
			optionMenu.SetActive (!_bool);

			EventSystem.current.SetSelectedGameObject (null);
			StartCoroutine (Wait (lastButton));
		}

		title.SetActive (_bool);
		star.SetActive (_bool);
		buttons.SetActive (_bool);
	}
}
