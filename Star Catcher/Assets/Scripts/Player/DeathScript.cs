using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour 
{
	Rigidbody character;
	Scene scene;

	void Start()
	{
		character = GetComponent<Rigidbody> ();	
		scene = SceneManager.GetActiveScene ();
	}

	void OnTriggerEnter(Collider coll)
	{
		if (coll.gameObject.layer == 11) 
		{
			SceneManager.LoadScene (scene.name);
			StaticVars.Reset ();
		}
	}

}
