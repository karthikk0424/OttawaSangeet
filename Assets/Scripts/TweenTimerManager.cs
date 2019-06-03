/*===============================================================
Developer:  Karthik Karunakaran
Company:    Vector3Games
================================================================*/

using UnityEngine;

public class TweenTimerManager : MonoBehaviour {
    #region singleton
    #endregion singleton

    #region events and delegates
    #endregion events and delegates

    //const
    
    //public
	public TweenPosition[] m_Tweens; 
	public Timer m_AdsTimer = new Timer();
    //protected

    //private

    #region properties
    #endregion properties

    #region structs
    #endregion structs
	
    #region Unity API methods
	public void Update()
	{
		if(m_AdsTimer != null)
		{
			m_AdsTimer.Update();
		}
	}

	public void Start()
	{
		m_AdsTimer.Start(60);
		m_AdsTimer.m_OnDone = null;
		m_AdsTimer.m_OnDone = OnTimerDone;
	}
    #endregion Unity API methods

    #region public methods
    #endregion public methods

    #region protected methods
    #endregion protected methods

    #region private methods
	private void OnTimerDone()
	{
		foreach (TweenPosition tween in m_Tweens)
		{
			tween.Play(true);
		}

		m_AdsTimer.Start(30);
		m_AdsTimer.m_OnDone = null;
		m_AdsTimer.m_OnDone = OnTweenFinished;
	}

	private void OnTweenFinished()
	{
		foreach (TweenPosition tween in m_Tweens)
		{
			tween.PlayReverse();
		}

		Start();
	}
    #endregion private methods
}