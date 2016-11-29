using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MuteAllSounds : MonoBehaviour
{
	Toggle soundToggle;

	void Start()
	{
		soundToggle = GetComponent<Toggle> ();
		AudioListener.pause = false;
	}

	public void Mute ()
	{
		AudioListener.pause = !soundToggle.isOn;
	}
}
