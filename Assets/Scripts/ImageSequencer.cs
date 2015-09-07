using UnityEngine;
using System.Collections;

public class ImageSequencer : MonoBehaviour {

	public float timeInterval = 2;
	public Texture[] images;
	public string LoadLevelName;
	private int index = 0;

	private void Start()
	{
		StartCoroutine(BeginLoop());
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
			if(LoadLevelName != null)
			{
				Application.LoadLevel(LoadLevelName);
			}
			index = 0;
		}
		StopAllCoroutines();
		StartCoroutine(BeginLoop());
	}
}
