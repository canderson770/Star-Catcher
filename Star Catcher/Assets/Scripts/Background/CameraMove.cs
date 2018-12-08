using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour 
{	
	[Range(0,0.3f)]
	public float cameraSpeed = .15f;

	StarSpawner starSpawner;

	Rigidbody camRB;

	void Start()
	{
		camRB = GetComponent<Rigidbody> ();
		starSpawner = GameObject.Find ("StarSpawner").GetComponent<StarSpawner> ();

		if (StaticVars.currentDifficulty == StaticVars.Difficulty.Easy) 
		{
			cameraSpeed -= 0.05f;
			starSpawner.spawnSeconds -= .5f;
		} 
		else if (StaticVars.currentDifficulty == StaticVars.Difficulty.Unfair)
		{
			cameraSpeed += 0.1f;
			starSpawner.spawnSeconds += .5f;
		}
	}
		
	void FixedUpdate ()
	{
		if(!StaticVars.isPaused)
			transform.Translate (cameraSpeed, 0, 0);
	}
}
