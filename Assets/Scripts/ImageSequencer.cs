using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ImageSequencer : MonoBehaviour {

	public float timeInterval = 2;
	public Texture[] images;
	public string LoadLevelName;
	private int index = 0;
    public bool m_SkipSequencer = false;

    [SerializeField] private List<string> m_MoviesToPlayInSequencer;

	private void Start()
	{
        if (m_SkipSequencer)
        {
            if (m_MoviesToPlayInSequencer.Count > 0)
            {
                MovieManager.Instance.m_QueuedMovieList = m_MoviesToPlayInSequencer;
                MovieManager.Instance.PlayVideo("", true, true, false);
            }
        }
        else
        {
            StartCoroutine(BeginLoop());
        }
		
	}

	private IEnumerator BeginLoop()
	{
		UITexture m_texture = GetComponent<UITexture>();
		m_texture.mainTexture = images[index];
		m_texture.MakePixelPerfect();
		index++;
		yield return new WaitForSeconds(timeInterval);
		
		if(index == images.Length)
        {
            if (m_MoviesToPlayInSequencer.Count > 0)
            {
                MovieManager.Instance.m_QueuedMovieList = m_MoviesToPlayInSequencer;
                MovieManager.Instance.PlayVideo("", true, true);
            }

			else if (!string.IsNullOrEmpty(LoadLevelName))
			{
				Application.LoadLevel(LoadLevelName);
			}

			index = 0;
		}
		StopAllCoroutines();
		StartCoroutine(BeginLoop());
	}
}
