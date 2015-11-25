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
			Application.LoadLevel("AcidRain");
		}
		else if(Input.GetKeyDown(KeyCode.Z))
		{
			Application.LoadLevel("OttawaSangeet");
		}
		else if(Input.GetKeyDown(KeyCode.S))
		{
			Application.LoadLevel("Shatter");
		}
		else if(Input.GetKeyDown(KeyCode.D))
		{
			Application.LoadLevel("Disco");
		}
		else if(Input.GetKeyDown(KeyCode.B))
		{
			Application.LoadLevel("ShatterLogo");
		}
		else if(Input.GetKeyDown(KeyCode.I))
		{
			Application.LoadLevel("Sequencer");
		}
		else if(Input.GetKeyDown(KeyCode.H))
		{
			Application.LoadLevel("Applauncher");
		}
		else if(Input.GetKeyDown(KeyCode.P))
		{
			Application.LoadLevel("Pookale");
		}
		else if(Input.GetKeyDown(KeyCode.C))
		{
			Application.LoadLevel("ChinnaChinna");
		}
		else if(Input.GetKeyDown(KeyCode.N))
		{
			Application.LoadLevel("Fire");
		}
		else if(Input.GetKeyDown(KeyCode.R))
		{
			Application.LoadLevel("Credits");
		}
		else if(Input.GetKeyDown(KeyCode.V))
		{
			Application.LoadLevel("SnowScene");
		}
		else if(Input.GetKeyDown(KeyCode.X))
		{
			Application.LoadLevel("SnowScene2");
		}
		else if(Input.GetKeyDown(KeyCode.K))
		{
			Application.LoadLevel("InShowTrailer");
		}
	}
}
