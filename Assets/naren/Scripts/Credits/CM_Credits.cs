using UnityEngine;
using System.Collections;

public class CM_Credits : MonoBehaviour 
{

	[SerializeField] internal Transform CreditHandler;
	// Start Position = (0, -6, 0)
	// End Position = (0, 52, 0)

	private Vector3 startPosition = new Vector3 (0, -12, 0);
	private Vector3 endPosition = new Vector3 (0, 56, 0);
	private AudioSource bgAudio;

	private float timer = 100f; // 274 for entire audio

	private void Awake ()
	{
		CreditHandler.position = startPosition;
	}


	private void Start()
	{
		if (timer < 1)
		{
			timer = 60f;
		}

		StartCoroutine (this.moveTransform ());
	}

	private void OnEnable ()
	{
		if (bgAudio == null) {
			bgAudio = this.GetComponent<AudioSource>();
				}
		}


	private IEnumerator moveTransform ()
	{
		if (bgAudio != null)
		{
			bgAudio.Play();
		}

		float _t = 0f;
		float _lastTime = Time.realtimeSinceStartup;

		CreditHandler.position = startPosition;
		while (_t<1)
		{
			CreditHandler.position = Vector3.Lerp (startPosition, endPosition, _t);
			_t += (Time.realtimeSinceStartup - _lastTime)/timer;
			_lastTime = Time.realtimeSinceStartup;
			yield return null;
		}
		CreditHandler.position = endPosition;

		if (bgAudio != null) {
						while (bgAudio.isPlaying) {
								yield return null;
						}
				}

		// Complete AUDIO

		// Complete translation

	}



}