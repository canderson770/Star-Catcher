using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour 
{
	public GameObject defaultSpawn;
	Rigidbody character;
	Scene scene;

	void Start()
	{
		character = GetComponent<Rigidbody> ();	
		scene = SceneManager.GetActiveScene ();
	}

	void OnTriggerEnter()
	{
//		Death ();
//		SceneManager.LoadScene ("Prototype 3");
		SceneManager.LoadScene(scene.name);
	}

	void Death()
	{
		character.velocity = new Vector3 (0, 0, 0);
		transform.position = defaultSpawn.transform.position;
	}
}
