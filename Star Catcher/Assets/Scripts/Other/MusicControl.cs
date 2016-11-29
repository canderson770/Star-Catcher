using UnityEngine;
using System.Collections;

public class MusicControl : MonoBehaviour 
{
	bool pause = false;
	AudioSource audio;

	void Start () 
	{
		audio = GetComponent<AudioSource> ();
		audio.ignoreListenerPause = true;
	}

	public void PauseMusic()
	{
		pause = !pause;

		if (pause)
			audio.Pause ();
		else
			audio.UnPause ();
	}
}
