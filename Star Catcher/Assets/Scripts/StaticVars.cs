using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class StaticVars : MonoBehaviour 
{
	public static float lastModule = 1;
	public static int starCount;
	public static bool isPaused = false;

	public static void Reset()
	{
		starCount = 0;
	}
}
