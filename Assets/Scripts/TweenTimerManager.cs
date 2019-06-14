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
	public TweenPosition m_ScrollRect; 
    //protected

    //private

    #region properties
    #endregion properties

    #region structs
    #endregion structs
	
    #region Unity API methods
	public void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha0))
		{
			m_ScrollRect.Play(true);
		}
		else if (Input.GetKeyDown(KeyCode.Alpha9))
		{
			m_ScrollRect.PlayReverse();
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