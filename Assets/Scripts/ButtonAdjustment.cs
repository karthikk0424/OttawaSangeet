/*===============================================================
Developer:  Karthik Karunakaran
Company:    Vector3Games
================================================================*/

using UnityEngine;

public class ButtonAdjustment : MonoBehaviour {
    #region singleton
    #endregion singleton

    #region events and delegates
    #endregion events and delegates

    //const
    
    //public
	[SerializeField] private Transform m_TopAnchor;
	[SerializeField] private Transform m_BottomAnchor;

	[SerializeField] private string m_TopAnchorSaveKey;
	[SerializeField] private string m_BottomAnchorSaveKey;
    //protected

    //private

    #region properties
    #endregion properties

    #region structs
    #endregion structs
	
    #region Unity API methods
	private void Awake()
	{
		//Lod positions
		LoadPositions();
		//m_BottomAnchor.localPosition
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.UpArrow))
		{
			m_TopAnchor.localPosition = m_TopAnchor.localPosition + Vector3.up * 3; 
			m_BottomAnchor.localPosition = m_BottomAnchor.localPosition + Vector3.up * 3; 

			SavePositions();
		}
		if(Input.GetKeyDown(KeyCode.DownArrow))
		{
			m_TopAnchor.localPosition = m_TopAnchor.localPosition + Vector3.down * 3;
			m_BottomAnchor.localPosition = m_BottomAnchor.localPosition + Vector3.down * 3; 
		
			SavePositions();
		}
	}

	private void SavePositions()
	{
		PlayerPrefs.SetString(m_TopAnchorSaveKey, JsonUtility.ToJson(m_TopAnchor.localPosition));
		PlayerPrefs.SetString(m_BottomAnchorSaveKey, JsonUtility.ToJson(m_BottomAnchor.localPosition));
	}

	private void LoadPositions()
	{
		var topFromSave = PlayerPrefs.GetString(m_TopAnchorSaveKey);
		if (!string.IsNullOrEmpty(topFromSave))
		{
			m_TopAnchor.localPosition = JsonUtility.FromJson<Vector3>(topFromSave);		
		}

		var bottomFromSave = PlayerPrefs.GetString(m_BottomAnchorSaveKey);
		if (!string.IsNullOrEmpty(bottomFromSave))
		{
			m_BottomAnchor.localPosition = JsonUtility.FromJson<Vector3>(bottomFromSave);		
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