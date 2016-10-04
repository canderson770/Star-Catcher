using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{	
	public float cameraSpeed = .1f;

	void Update ()
	{
		transform.Translate (cameraSpeed, 0, 0);
	}
}