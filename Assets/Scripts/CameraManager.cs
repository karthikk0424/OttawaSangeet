using UnityEngine;
using System.Collections;

public class CameraManager : MonoBehaviour {

	// Use this for initialization
	private static CameraManager _instance ;
	// Use this for initialization
	void Start () {
		if(!_instance)
			_instance = this ;
		//otherwise, if we do, kill this thing
		else
			Destroy(this.gameObject) ;
		
		DontDestroyOnLoad(this.gameObject);
	}
}
