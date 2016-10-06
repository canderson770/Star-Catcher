using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DistanceText : MonoBehaviour 
{
	Text distanceText;
	float distance;

	public GameObject cam;

	void Start()
	{
		distanceText = GetComponent<Text> ();
	}

	void Update()
	{
		distance = cam.transform.position.x / 10;
		distanceText.text = "Distance: " + distance.ToString("F0");
	}
}
