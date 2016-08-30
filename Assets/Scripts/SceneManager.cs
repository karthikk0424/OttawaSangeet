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
		if(Input.GetKeyDown(KeyCode.Z))
		{
			Application.LoadLevel("OttawaSangeet");
		}
        else if (Input.GetKeyDown(KeyCode.X))
        {
            Application.LoadLevel("ColorfulRays");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Application.LoadLevel("TravelNebula");
        }
        else if (Input.GetKeyDown(KeyCode.V))
        {
            Application.LoadLevel("Halo");
        }
        else if (Input.GetKeyDown(KeyCode.B))
        {
            Application.LoadLevel("BlueMotion");
        }
        else if (Input.GetKeyDown(KeyCode.N))
        {
            Application.LoadLevel("Fire");
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            Application.LoadLevel("Moon");
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            Application.LoadLevel("Accelerate");
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            Application.LoadLevel("Splash");
        }
		else if(Input.GetKeyDown(KeyCode.D))
		{
			Application.LoadLevel("Disco");
		}
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Application.LoadLevel("Flame");
        }
        else if (Input.GetKeyDown(KeyCode.G))
        {
            Application.LoadLevel("MagicalGround");
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            Application.LoadLevel("Applauncher");
        }
		else if(Input.GetKeyDown(KeyCode.I))
		{
			Application.LoadLevel("Sequencer");
        }
        else if (Input.GetKeyDown(KeyCode.Q))
        {
            Application.LoadLevel("RainbowFlare");
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            Application.LoadLevel("RainbowSpace");
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            Application.LoadLevel("GlowingRing");
        }
		else if(Input.GetKeyDown(KeyCode.R))
		{
            Application.LoadLevel("CreditsFireworks");
        }
	}
}
