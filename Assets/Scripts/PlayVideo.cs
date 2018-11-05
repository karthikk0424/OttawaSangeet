using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine.SceneManagement;

public class PlayVideo : MonoBehaviour {
	
	public string LoadLevel;
    public AudioClip m_CustomAudioClip;
    public bool m_UseCustomAudio = false;
    public List<MovieTexture> m_Movies = null;
    private MovieTexture movie;
    [SerializeField ]private List<GameObject> m_ObjectToBeHidden = new List<GameObject>();

    public void Start()
	{
        if (m_ObjectToBeHidden.Count > 0 && MovieManager.Instance.ShouldHideObjects)
        {
            m_ObjectToBeHidden.ForEach(x => x.SetActive(false));
        }
        movie = GetMovieFromName();
        GetComponent<Renderer>().material.mainTexture = movie;
        if (MovieManager.Instance.ShouldPlayAudio)
		{
            AudioSource audioSource = GetComponent<AudioSource>();

            if (audioSource == null)
            {
                audioSource = gameObject.AddComponent<AudioSource>();
            }
            if (MovieManager.Instance.ShouldPlayAudio)
            {
                audioSource.clip = movie.audioClip;
                audioSource.Play();
            }
            else if (m_UseCustomAudio)
            {
                AudioManager.Instance.PlayAudioClip(m_CustomAudioClip);
            }
		}
		movie.Play();
	}

    private MovieTexture GetMovieFromName()
    {
        foreach (MovieTexture movie in m_Movies)
        {
            if (MovieManager.Instance.MovieName == movie.name)
            {
                return movie;
            }
        }
        return m_Movies[0];
    }
    private void Update()
	{
		if(movie != null)
		{
			if(!movie.isPlaying)
			{
				if(MovieManager.Instance.ShouldLoop)
				{
					movie.Stop();
					Start();
					return;
				}
                if (MovieManager.Instance.IsanyMovieInQueue)
                {
                    MovieManager.Instance.ContinueWithQueue();
                }
				else if (!string.IsNullOrEmpty(OttawaSangeet.SceneManager.ParentScene))
				{
                    SceneManager.LoadScene(OttawaSangeet.SceneManager.ParentScene);
				}
			}
		}
	}
	
}
