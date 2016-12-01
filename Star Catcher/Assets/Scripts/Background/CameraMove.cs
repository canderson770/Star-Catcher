using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{	
	[Range(0,0.3f)]
	public float cameraSpeed = .15f;

	Rigidbody camRB;

	void Start()
	{
		camRB = GetComponent<Rigidbody> ();
//		MoveCamera ();
	}
		
	void Update ()
	{
		if(!StaticVars.isPaused)
			transform.Translate (cameraSpeed, 0, 0);
	}
//
//	 void StopCamera()
//	{
//		camRB.velocity = new Vector3(0, 0, 0);	
//	}
//
//	void MoveCamera()
//	{
//		camRB.AddForce (new Vector3(500, 0, 0), ForceMode.VelocityChange);
//	}
}