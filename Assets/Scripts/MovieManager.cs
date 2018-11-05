/*===============================================================
Developer:  Karthik Karunakaran
Company:    Vector3Games
================================================================*/

using UnityEngine;
using System.Collections.Generic;
using System.Linq;

using Vector3Games.Core;

public class MovieManager :  Singleton<MovieManager>
{
    #region singleton    
    #endregion singleton

    #region events and delegates
    #endregion events and delegates

    //const

    //public

    //protected

    //private
    public List<string> m_QueuedMovieList;
    private string m_MovieName = string.Empty;
    private bool m_ShouldPlayAudio = false;
    private bool m_ShouldHideObjects = false;
    private bool m_ShouldLoop = true;

    #region properties
    public string MovieName
    {
       get
        {
            return m_MovieName;
        }
    }

    public bool ShouldPlayAudio
    {
        get
        {
            return m_ShouldPlayAudio;
        }
    }

    public bool ShouldHideObjects
    {
        get
        {
            return m_ShouldHideObjects;
        }
    }
    public bool IsanyMovieInQueue
    {
       get
        {
			return m_QueuedMovieList != null && m_QueuedMovieList.Count > 0;
        }
    }

    public bool ShouldLoop
    {
        get
        {
            return m_ShouldLoop;
        }
    }
    #endregion properties

    #region structs
    #endregion structs

    #region Unity API methods
    #endregion Unity API methods

    #region public methods
    public void ContinueWithQueue()
    {
        PlayVideo("", m_ShouldPlayAudio, m_ShouldHideObjects);
    }
    public void ClearQueue()
    {
        if (m_QueuedMovieList != null)
        {
            m_QueuedMovieList.Clear();
        }        
    }
    public void PlayVideo(string movie = "Party",  bool shouldPlayAudio = false, bool shouldHideObjects = false, bool shouldLoop = false)
    {

        if (m_QueuedMovieList != null && m_QueuedMovieList.Count > 0)
        {
            var random = new System.Random();
            int index = random.Next(m_QueuedMovieList.Count);

            m_MovieName = m_QueuedMovieList[0];
            m_QueuedMovieList.Remove(m_MovieName);
        }
        else
        {
            m_MovieName = movie;   
        }

        m_ShouldHideObjects = shouldHideObjects;
        m_ShouldPlayAudio = shouldPlayAudio;
        m_ShouldLoop = shouldLoop;

        if (Application.loadedLevelName != "MainScreen")
        {
            OttawaSangeet.SceneManager.ParentScene = Application.loadedLevelName;
        }

        Application.LoadLevel("MainScreen");
    }
    #endregion public methods

    #region protected methods
    #endregion protected methods

    #region private methods
    #endregion private methods
}