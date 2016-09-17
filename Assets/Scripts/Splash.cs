using UnityEngine;
using System.Collections;

public class Splash : MonoBehaviour {
    private float audio1Volume = 1;
    private bool m_startFade = false;
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Application.LoadLevel("Applauncher");
        }
        else if (Input.GetKeyDown(KeyCode.I))
        {
            Application.LoadLevel("Intro");
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            m_startFade = true;
        }
        if (m_startFade)
        {
            FadeOut();
        }
	}

    private void FadeOut()
    {
        if (audio1Volume > 0)
        {
            audio1Volume -= 0.1f * Time.deltaTime;
            AudioManager.Instance.m_MusicAudioSource1.volume = audio1Volume;
        }

        if (audio1Volume <= .05f)
        {
            m_startFade = false;
            AudioManager.Instance.StopAudio();
        }
    }
}
