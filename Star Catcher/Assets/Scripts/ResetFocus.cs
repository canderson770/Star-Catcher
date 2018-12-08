using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class ResetFocus : MonoBehaviour 
{
	 GameObject firstButton;

	void Start()
	{
		firstButton = GameObject.Find ("Start");
	}

	void Update()
	{
		if (EventSystem.current.currentSelectedGameObject == null)
			EventSystem.current.SetSelectedGameObject (firstButton);

		firstButton = EventSystem.current.currentSelectedGameObject;
	}
}
