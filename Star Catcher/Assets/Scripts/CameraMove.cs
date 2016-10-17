using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{	
	public float cameraSpeed = .15f;

	void Update ()
	{
		if(!StaticVars.isPaused)
			transform.Translate (cameraSpeed, 0, 0);
	}
}