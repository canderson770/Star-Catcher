﻿using UnityEngine;
using System.Collections;

public class DontDestroy : MonoBehaviour 
{
	void Start () 
	{
		DontDestroyOnLoad (transform.gameObject);
	}

}
