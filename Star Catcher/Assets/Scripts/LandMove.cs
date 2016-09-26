using UnityEngine;
using System.Collections;

public class LandMove : MonoBehaviour
{

	void Update ()
	{
		transform.Translate (-.1f, 0, 0);
	}
}