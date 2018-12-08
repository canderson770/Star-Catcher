using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuStarText : MonoBehaviour
{
	Text stars;

	void Start () 
	{
		stars = GetComponent<Text> ();
		SetStarCount ();
	}

	public void SetStarCount()
	{
		stars.text = PlayerPrefs.GetInt ("TotalStars", 0).ToString ();
	}
}
