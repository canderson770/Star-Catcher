using UnityEngine;
using UnityEngine.Audio;
using System.Collections;

public class MyPlayClipAtPoint : MonoBehaviour 
{
	public static GameObject temp;
	public static AudioSource audio;

	public static void _PlayClipAtPoint(AudioClip _clip, Transform _pos, float _vol, Transform _parent, AudioMixerGroup mixerGroup)
	{
		GameObject temp = new GameObject();
		temp.transform.position = _pos.position;
		temp.AddComponent<AudioSource>();
		temp.name = "star bounce oneshot";
		temp.transform.SetParent (_parent);

		AudioSource audio = temp.GetComponent<AudioSource> ();
        audio.outputAudioMixerGroup = mixerGroup;
        audio.playOnAwake = false;
		audio.clip = _clip;
		audio.volume = _vol;
		audio.Play ();

		Destroy (temp, audio.clip.length);
	}
}
