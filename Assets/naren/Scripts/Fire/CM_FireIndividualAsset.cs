using UnityEngine;
using System.Collections;

public class CM_FireIndividualAsset : MonoBehaviour 
{
	private ParticleSystem myParticleSystem;
	private MeshRenderer myRenderer;

	// Cache the particle system
	// Stop the particle system

	private void OnEnable ()
	{
		if(myParticleSystem == null)
		{
			myParticleSystem = this.GetComponent<ParticleSystem>();
		}

		if(myRenderer == null)
		{
			myRenderer = this.GetComponent<MeshRenderer>();
		}
	}

	private void Start ()
	{
		myRenderer.enabled = false;
		myParticleSystem.Stop();
	}

	internal void PlayFireAnimation ()
	{
		myParticleSystem.Play();
	}

	internal void StopFireAnimation ()
	{
		myParticleSystem.Stop();
	}
}
