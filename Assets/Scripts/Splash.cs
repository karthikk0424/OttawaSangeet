﻿using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Application.LoadLevel("Applauncher");
        }
	}
}
