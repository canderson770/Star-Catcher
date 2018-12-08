using UnityEngine;
using System.Collections;

public class StarCatch : MonoBehaviour 
{
	//Private Variables
	StarsText starsText;
	UIBar uiBar;

    //Public Variable
    //public AudioClip clip;
    public AudioSource source;

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
            //AudioSource.PlayClipAtPoint (clip, coll.transform.position);
            source.Play();
            starsText.UpdateStars ();
			uiBar.UpdateBar ();
		}	
	}
}
