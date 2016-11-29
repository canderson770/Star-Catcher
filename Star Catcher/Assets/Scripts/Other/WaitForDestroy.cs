using UnityEngine;
using System.Collections;

public class WaitForDestroy : MonoBehaviour
{
	public int secondsToWait;

	void Start () 
	{
		Destroy (gameObject, secondsToWait);
	}
}
