using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

//==================================================================================================================================
[System.Serializable]
public class HighScoreObject
{
	string name;
	int score;

	public HighScoreObject(string _n, int _s)
	{
		name = _n;
		score = _s;
	}

	public string GetName()
	{
		return name;
	}

	public int GetScore()
	{
		return score;
	}
}

//==================================================================================================================================
public class Leaderboard : MonoBehaviour 
{
	[HideInInspector]
	public List<HighScoreObject> leaderboard;

	GameObject highScorePanel;
	Text inputFieldText;

	GameObject resumeBtn;
	MenuStarText starCount;

	[HideInInspector]
	public GameObject inputField;

	[HideInInspector]
	public GameObject doneBtn;

	Animator anim;
	Text scoreList;
	Text nameList;
	int max = 7;
	int index;

	void Awake() 
	{
		if (SceneManager.GetActiveScene ().name == "Main Menu")
		{
			scoreList = GameObject.Find ("ScoreList").GetComponent<Text> ();
			nameList = GameObject.Find ("NameList").GetComponent<Text> ();
			starCount = GameObject.Find ("StarCount").GetComponent<MenuStarText> ();

//			if (PlayerPrefs.GetInt ("listChanged", 0) == 0) 
//			{
//				print ("RESET TO DEFAULT");
//				leaderboard.Add (new HighScoreObject ("Bill", 733));
//				leaderboard.Add (new HighScoreObject ("Phil", 273));
//				leaderboard.Add (new HighScoreObject ("Jane", 153));
//				leaderboard.Add (new HighScoreObject ("Ben", 130));
//				leaderboard.Add (new HighScoreObject ("Fred", 111));
//				leaderboard.Add (new HighScoreObject ("Jack", 52));
//				leaderboard.Add (new HighScoreObject ("Bobby", 10));
//				SetList ();
//			}
		} 
		else if (SceneManager.GetActiveScene ().buildIndex == 2) 
		{
			highScorePanel = GameObject.Find("NewHighScorePanel");
			inputField = GameObject.Find("InputField");
			inputFieldText = GameObject.Find("Input").GetComponent<Text>();
			doneBtn = GameObject.Find("DoneButton");
			resumeBtn = GameObject.Find ("ResumeButton");

			highScorePanel.SetActive (false);
			anim = GameObject.Find ("Canvas").GetComponent<Animator> ();
		}
}

	public void SetList()
	{
		for (int i = 0; i < max; i++) 
		{
			PlayerPrefs.SetString("name" + i, leaderboard [i].GetName());
			PlayerPrefs.SetInt("score" + i, leaderboard [i].GetScore());
		}
	}

	void GetList()
	{
		leaderboard.Clear ();
		for (int i = 0; i < max; i++) 
		{
			string _name = PlayerPrefs.GetString("name" + i, "Dummy");
			int _score = PlayerPrefs.GetInt("score" + i, 0);
			leaderboard.Add(new HighScoreObject(_name, _score));
		}
	}

	public void UpdateText () 
	{
		GetList ();

		string tempName = "";
		string tempScore = "";

		for (int i = 0; i < max; i++) 
		{
			tempName = tempName + leaderboard [i].GetName() + "\n";
			tempScore += leaderboard [i].GetScore().ToString("n0") + "\n";
		}

		nameList.text = tempName;
		scoreList.text = tempScore;
	}

	public void CheckForHighScore()
	{
		GetList ();

		for (int i = 0; i < max; i++) 
		{
			if (StaticVars.score > leaderboard [i].GetScore())
			{
				NewHighScore (i);	
				break;
			} 
			else if (StaticVars.score == leaderboard [i].GetScore() && i < 6) 
			{
				NewHighScore (i + 1);
				break;
			}
			else		
				EventSystem.current.SetSelectedGameObject (resumeBtn);
		}
	}

	void NewHighScore(int _i)
	{
		PlayerPrefs.SetInt ("listChanged", 1);
		print ("==================NEW HIGH SCORE==================");
		index = _i;

		highScorePanel.SetActive (true);
		anim.Play("newHighScore");

		EventSystem.current.SetSelectedGameObject (inputField);
	}


	public void SetHighScore()
	{
		if (inputFieldText.text != "") 
		{
			leaderboard.RemoveAt (max - 1);
			leaderboard.Insert (index, new HighScoreObject (inputFieldText.text, StaticVars.score));
			SetList ();
			highScorePanel.SetActive (false);
			anim.Play ("Pause");
			EventSystem.current.SetSelectedGameObject (null);
		}
	}


	public void DeleteAllData()
	{
		PlayerPrefs.DeleteAll ();
		print ("Deleted PlayerPrefs");
		starCount.SetStarCount ();
	}

//	void DebugList () 
//	{
//		GetList ();
//
//		for (int i = 0; i < max; i++) 
//		{
//			print(PlayerPrefs.GetString("name" + i, "Dummy")  + "\t" + PlayerPrefs.GetInt("score" + i, 0000));
//		}
//	}
}

