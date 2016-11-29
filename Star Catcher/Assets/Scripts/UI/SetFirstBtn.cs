using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SetFirstBtn : MonoBehaviour 
{
	public EventSystem myEventSystem;
	public GameObject firstButton;

	public void SetFocusBtn()
	{
		myEventSystem.SetSelectedGameObject(firstButton);
	}
}
