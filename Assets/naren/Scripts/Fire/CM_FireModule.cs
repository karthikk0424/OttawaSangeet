using UnityEngine;
using System.Collections;

public class CM_FireModule : MonoBehaviour 
{
//	[SerializeField] internal bool loopFIRE = true;
	[SerializeField] internal float TimerBetweenEachFire = 0f;
	// Cache the array of all the individual CM_FireIndividualAsset
	[SerializeField] internal CM_FireIndividualAsset[] myFireChildren;
	// Method to enable/disable them 

	// Method followed by a co rotuine to initiate them simultaneously
	internal void StarttheFiremodules (float _timer)
	{
		if(myFireChildren.Length < 1)
		{
			return;
		}
		if(TimerBetweenEachFire == 0)
		{
			TimerBetweenEachFire = _timer;
		}
		StartCoroutine( fireEachModule());
	}


	private IEnumerator fireEachModule ()
	{
		foreach(CM_FireIndividualAsset fr in myFireChildren)
		{
			fr.PlayFireAnimation();
			yield return new WaitForSeconds (TimerBetweenEachFire);
		}
		yield return null;

		CM_FireManager.Instance.CompletedThisFireModule();
	}


}
