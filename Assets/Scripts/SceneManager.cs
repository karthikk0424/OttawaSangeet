using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.I))
		{
			Application.LoadLevel("Main");
		}
		else if(Input.GetKeyDown(KeyCode.T))
		{
			Application.LoadLevel("Tara");
		}
		else if(Input.GetKeyDown(KeyCode.S))
		{
			Application.LoadLevel("Shashank");
		}
		else if(Input.GetKeyDown(KeyCode.H))
		{
			Application.LoadLevel("Home");
		}
	}
}
