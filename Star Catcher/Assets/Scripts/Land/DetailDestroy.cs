using UnityEngine;
using System.Collections;

public class DetailDestroy : MonoBehaviour 
{
	void OnTriggerExit () 
	{
		Destroy (gameObject);
	}
}
