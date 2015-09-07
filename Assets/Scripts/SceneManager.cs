using UnityEngine;
using System.Collections;

public class SceneManager : MonoBehaviour {

	private static SceneManager _instance ;
	// Use this for initialization
	void Start () {
		if(!_instance)
			_instance = this ;
		//otherwise, if we do, kill this thing
		else
			Destroy(this.gameObject) ;
		
		DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update()
	{
		if(Input.GetKeyDown(KeyCode.P))
		{
			Application.LoadLevel("TheePori");
		}
		else if(Input.GetKeyDown(KeyCode.Y))
		{
			Application.LoadLevel("Acid");
		}
		else if(Input.GetKeyDown(KeyCode.S))
		{
			Application.LoadLevel("Shatter");
		}
		else if(Input.GetKeyDown(KeyCode.L))
		{
			Application.LoadLevel("Sequencer");
		}
		else if(Input.GetKeyDown(KeyCode.H))
		{
			Application.LoadLevel("Applauncher");
		}
	}
}
