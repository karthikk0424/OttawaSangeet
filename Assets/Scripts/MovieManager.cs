/*===============================================================
Developer:  Karthik Karunakaran
Company:    Vector3Games
================================================================*/

using UnityEngine;
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
    private string m_MovieName = string.Empty;
    private bool m_ShouldPlayAudio = false;

    #region properties
    public string MovieName
    {
       get
        {
            return m_MovieName;
        }
    }

    private bool ShouldPlayAudio
    {
        get
        {
            return m_ShouldPlayAudio;
        }
    }
    #endregion properties

    #region structs
    #endregion structs

    #region Unity API methods
    #endregion Unity API methods

    #region public methods
    public void PlayVideo(string movie, bool shouldPlayAudio)
    {
        m_MovieName = movie;
        m_ShouldPlayAudio = shouldPlayAudio;

        Application.LoadLevel("MainScreen");
    }
    #endregion public methods

    #region protected methods
    #endregion protected methods

    #region private methods
    #endregion private methods
}