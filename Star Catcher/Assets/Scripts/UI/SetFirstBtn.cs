using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SetFirstBtn : MonoBehaviour 
{
	public GameObject firstButton;

	public void SetFocusBtn()
	{
		EventSystem.current.SetSelectedGameObject(firstButton);
	}
}
