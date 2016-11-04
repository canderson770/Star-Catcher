using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StaticVars : MonoBehaviour 
{
	public static int score = 0;
	public static int starCount = 0;
	public static int starBarCount = 0;
	public static float distance = 0;
	public static float time = 0;
	public static int randomNegPos = 0;

	public static bool isPaused = false;
	public static bool isGrounded = false;
	public static bool gameOver = false;

	public static void Reset()
	{
		score = 0;
		starCount = 0;
		starBarCount = 0;
		gameOver = false;
		isPaused = false;
	}

	public static void GameOver()
	{
		StaticVars.gameOver = true;
		StaticVars.isPaused = true;
	}
}
