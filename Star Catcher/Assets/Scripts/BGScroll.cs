using UnityEngine;
using System.Collections;

public class BGScroll : MonoBehaviour 
{
	Renderer background;

	public float bgSpeed = .02f;

	void Start()
	{
		background = GetComponent<Renderer> ();
	}

	void Update ()
	{
		if (!StaticVars.isPaused)
		{
			float bgOffset = Time.time * bgSpeed;

			background.material.mainTextureOffset = new Vector2 (bgOffset, 0);
		}
	}
}
