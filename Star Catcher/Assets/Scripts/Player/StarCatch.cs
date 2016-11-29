using UnityEngine;
using System.Collections;

public class StarCatch : MonoBehaviour 
{
	public AudioClip star;
	StarsText starsText;
	UIBar uiBar;

	void Start()
	{
		GameObject starsTextGameObject = GameObject.Find ("StarsNums");
		starsText = starsTextGameObject.GetComponent<StarsText> ();

		GameObject uiBarGameObject = GameObject.Find ("Full Bar");
		uiBar = uiBarGameObject.GetComponent<UIBar> ();
	}

	void OnTriggerEnter (Collider coll) 
	{
		if (coll.gameObject.layer == 15)
		{
			Destroy (coll.gameObject.transform.parent.gameObject);
			StaticVars.starCount++; 
			StaticVars.starBarCount++;
			AudioSource.PlayClipAtPoint (star, transform.position, 1);
			starsText.UpdateStars ();
			uiBar.UpdateBar ();
		}	
	}
}
