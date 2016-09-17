using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Application.LoadLevel("Applauncher");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            Application.LoadLevel("Intro");
        }
	}
}
