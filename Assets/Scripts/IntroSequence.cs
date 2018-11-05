/*===============================================================
Developer:  Karthik Karunakaran
Company:    Vector3Games
================================================================*/

using UnityEngine;

public class IntroSequence : MonoBehaviour {
    #region singleton
    #endregion singleton

    #region events and delegates
    #endregion events and delegates

    //const
    
    //public
    
    //protected

    //private
	[SerializeField] private GameObject m_ArtistButton;
	[SerializeField] private TweenScale m_PunchScale;
	[SerializeField] private ParticleSystem m_SpiralSpinner;
	[SerializeField] private ParticleSystem m_BlueWave;
    #region properties
    #endregion properties

    #region structs
    #endregion structs
	
    #region Unity API methods
	private void Start()
	{
		if (m_ArtistButton != null)
		{
			m_ArtistButton.SetActive(true);
			if(m_PunchScale != null)
			{
				m_PunchScale.PlayForward();
			}

			if (m_BlueWave != null)
			{
				m_BlueWave.Play();
			}

//			if (m_SpiralSpinner != null)
//			{
//				m_SpiralSpinner.Play();
//			}
		}
	}
    #endregion Unity API methods

    #region public methods
    #endregion public methods

    #region protected methods
    #endregion protected methods

    #region private methods
    #endregion private methods
}