using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {


    public static bool IsInstanceNull
    {
        get { return m_Instance == null; }
    }
    void OnDestroy()
    {
        m_IsDestroyed = true;
    }
    void Awake()
    {
        if (m_Instance != null)
        {
#if UNITY_EDITOR
            Debug.LogWarning("AudioManager has already been initialized.");
#endif
            return;
        }

        m_Instance = this;
        m_MusicAudioSource1 = gameObject.AddComponent<AudioSource>();
    }
    public static AudioManager Instance
    {
        get
        {
            if (m_IsDestroyed)
            {
                return null;
            }

            if (m_Instance == null)
            {
                GameObject audioManagerObj = GameObject.Find("AudioManager");
                if (audioManagerObj == null)
                {
                    audioManagerObj = new GameObject("AudioManager");
                }
                m_Instance = audioManagerObj.GetComponent<AudioManager>();
                if (m_Instance == null)
                {
                    m_Instance = audioManagerObj.AddComponent<AudioManager>();
                }
                DontDestroyOnLoad(audioManagerObj);
            }
            return m_Instance;
        }
    }

    private static bool m_IsDestroyed = false;
    public AudioSource m_MusicAudioSource1 = null;
    private static AudioManager m_Instance = null;

    public void PlayAudioClip(AudioClip clip)
    {
        m_MusicAudioSource1.clip = clip;
        m_MusicAudioSource1.Play();
    }

    public void StopAudio()
    {
        m_MusicAudioSource1.Stop();
        m_MusicAudioSource1.clip = null;
        m_MusicAudioSource1.volume = 1;
    }
}
