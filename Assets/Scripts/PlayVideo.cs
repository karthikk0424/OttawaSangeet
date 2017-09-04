using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayVideo : MonoBehaviour {
	
	public MovieTexture movie;
	public string LoadLevel;
	public bool PlayAudio = false;
	public bool loop = false;
    public AudioClip m_CustomAudioClip;
    public bool m_UseCustomAudio = false;
    public List<MovieTexture> m_Movies = null;

	public void Start()
	{
		GetComponent<Renderer>().material.mainTexture = movie;
		if(PlayAudio)
		{
            AudioSource audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
            if (!m_UseCustomAudio)
            {
                audioSource.clip = movie.audioClip;
                audioSource.Play();
            }
            else
            {
                AudioManager.Instance.PlayAudioClip(m_CustomAudioClip);
            }
		}
		movie.Play();
	}

	public void Update()
	{
		if(movie != null)
		{
			if(!movie.isPlaying)
			{
				if(loop)
				{
					movie.Stop();
					Start();
					return;
				}
				if(!string.IsNullOrEmpty(LoadLevel))
				{
					Application.LoadLevel(LoadLevel);
				}
			}
		}
	}
	
}
