﻿using UnityEngine;
using System.Collections;

public class PlayVideo : MonoBehaviour {
	
	public MovieTexture movie;
	public string LoadLevel;
	public bool PlayAudio = false;
	public bool loop = false;

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
            audioSource.clip = movie.audioClip;
            audioSource.Play();
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
