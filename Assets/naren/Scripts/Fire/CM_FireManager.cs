using UnityEngine;
using System.Collections;

public class CM_FireManager : MonoBehaviour 
{
	protected static bool isFIREMODULECOMPLETE = false;

	[SerializeField] internal CM_FireModule[] myModules;
	[SerializeField] internal float TimerBetweenEachModule;
	[SerializeField] internal float GlobalTimerBetweenEachFire;



	private void Awake ()
	{
		instance = this;
	}

	#region SINGLETON 
	private static CM_FireManager instance;
	public static CM_FireManager Instance
	{		
		get
		{
			if(instance == null)
			{	
				instance = UnityEngine.Object.FindObjectOfType(typeof(CM_FireManager)) as CM_FireManager;
				if (instance == null)
				{
					GameObject go = new GameObject("_CM_FireManager");
					instance = go.AddComponent<CM_FireManager>();		
				}
			}
			return instance;
		}
	}	
	#endregion

	private void Start ()
	{
		isFIREMODULECOMPLETE = false;
		StartCoroutine ( this.startTheFireRoll());
	}


	private IEnumerator startTheFireRoll()
	{
		foreach( CM_FireModule fr in myModules)
		{
			isFIREMODULECOMPLETE = false;
			fr.StarttheFiremodules( GlobalTimerBetweenEachFire);

			while (isFIREMODULECOMPLETE == false)
			{
				yield return null;
			}
			yield return new WaitForSeconds (TimerBetweenEachModule);
		}
		Debug.Log ("Completed Operation!!!");
		// End Of Operation
	}

	internal void CompletedThisFireModule ()
	{
		isFIREMODULECOMPLETE = true;
	}



}
