using UnityEngine;
using System.Collections;

public class DontDestroyThisObject : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		DontDestroyOnLoad(this.gameObject);
	}
}
