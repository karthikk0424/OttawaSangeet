using UnityEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

public class MainScreenManager : MonoBehaviour 
{
	private TweenPosition m_Tween;
    private TweenPosition m_OctaneiTween;
    private TweenPosition m_ChitraiTween;
    private TweenPosition m_CineMusiqiTween;

    public GameObject tweenTarget;
    public GameObject m_OctaneObject;
    public GameObject m_ChitraObject;
    public GameObject m_CineMusiqObject;
    public UILabel SongTitleText;
	public UILabel SingerText;
    public UILabel ChorusText;
    public UILabel DanceText;
    public string SongListName;

	private void ResetTween()
	{
		m_Tween.from = Vector3.zero;
		m_Tween.to = Vector3.zero;
	}

	private void PlaySingerTween()
	{
		m_Tween = tweenTarget.AddComponent<TweenPosition>();
		m_Tween.AddOnFinished(RemoveTweenOnFinish);
		m_Tween.from = Vector3.zero;
		m_Tween.to = new Vector3(0, -1200, 0);
		m_Tween.PlayForward();
		Invoke("PlayTitleTween", 10);
        PlayOctaneTween();
        PlayChitraTween();
        PlayCineMusiqTween();
    }

    /// <summary>
    /// PlayOctaneTween
    /// </summary>
    private void PlayOctaneTween()
    {
        m_OctaneiTween = m_OctaneObject.AddComponent<TweenPosition>();
        m_OctaneiTween.from = Vector3.zero;
        m_OctaneiTween.to = new Vector3(725, 0, 0);
        m_OctaneiTween.PlayForward();
    }
    /// <summary>
    /// PlayChitraTween
    /// </summary>
    private void PlayChitraTween()
    {
        m_ChitraiTween = m_ChitraObject.AddComponent<TweenPosition>();
        m_ChitraiTween.from = Vector3.zero;
        m_ChitraiTween.to = new Vector3(-700, 0, 0);
        m_ChitraiTween.PlayForward();
    }
    /// <summary>
    /// PlayChitraTween
    /// </summary>
    private void PlayCineMusiqTween()
    {
        m_CineMusiqiTween = m_CineMusiqObject.AddComponent<TweenPosition>();
        m_CineMusiqiTween.from = Vector3.zero;
        m_CineMusiqiTween.to = new Vector3(0, 250, 0);
        m_CineMusiqiTween.PlayForward();
    }
    private void PlayTitleTween()
	{
		m_Tween = tweenTarget.AddComponent<TweenPosition>();
		m_Tween.AddOnFinished(() =>
        {
            if (tweenTarget.GetComponent<TweenPosition>() != null)
            {
                Destroy(m_Tween);
            }
        });
		m_Tween.from = new Vector3(0, 300, 0);
		m_Tween.to = Vector3.zero;
		m_Tween.PlayForward();
        m_OctaneiTween.PlayReverse();
        m_OctaneiTween.AddOnFinished(() =>
        {
            if (m_OctaneObject.GetComponent<TweenPosition>() != null)
            {
                Destroy(m_OctaneiTween);
            }
        });

        m_ChitraiTween.PlayReverse();
        m_ChitraiTween.AddOnFinished(() =>
        {
            if (m_ChitraObject.GetComponent<TweenPosition>() != null)
            {
                Destroy(m_ChitraiTween);
            }
        });

        m_CineMusiqiTween.PlayReverse();
        m_CineMusiqiTween.AddOnFinished(() =>
        {
            if (m_CineMusiqObject.GetComponent<TweenPosition>() != null)
            {
                Destroy(m_CineMusiqiTween);
            }
        });
    }

	private void PlayAdTween()
	{
		m_Tween = tweenTarget.AddComponent<TweenPosition>();
		m_Tween.AddOnFinished(RemoveTweenOnFinish);
		m_Tween.from = Vector3.zero;
		m_Tween.to = new Vector3(0, 1108, 0);
		m_Tween.PlayForward();
        Invoke("PlayTitleTween", 10);
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.U))
		{
			//PlayTitleTween();
		}
		else if(Input.GetKeyDown(KeyCode.A))
		{
			//PlayAdTween();
		}
		if(stringToEdit.EndsWith("t"))
		{
			char[] trim = {'t'};

            if (LoadSongText(stringToEdit.Trim(trim)))
            {
                PlaySingerTween();
            }
			    
            stringToEdit = "";
        }
	}

	private void RemoveTweenOnFinish()
	{
    }

	private bool LoadSongText(string trackNumber)
	{
		XmlDocument document = new XmlDocument();
		document.Load(Application.streamingAssetsPath + "/" + SongListName + ".xml");
        int songNumber = 0;

        SongTitleText.text = "";
        SingerText.text = "";
        ChorusText.text = "";
        DanceText.text = "";

		foreach (XmlNode node in document.GetElementsByTagName("Song"))
		{
			if (node.Attributes["Number"].Value == trackNumber)
			{
				SongTitleText.text = node.Attributes["Name"].Value;
				songNumber = Int32.Parse(node.Attributes["Number"].Value);
                SingerText.text = node.Attributes["Singers"].Value;
                ChorusText.text = node.Attributes["Chorus"].Value;

                if (ChorusText.text == "")
                {
                    ChorusText.text = node.Attributes["Dance"].Value;
                }
                else
                {
                    DanceText.text = node.Attributes["Dance"].Value;
                }
                return true;
			}
		}
        return false;
	}

	private string stringToEdit = "";
	private void OnGUI() {
		GUI.SetNextControlName("CMTextField");
		stringToEdit = GUI.TextField(new Rect(100, Screen.height - 20, 20, 20), stringToEdit, 25);
		if (GUI.Button(new Rect(0, Screen.height - 20, 80, 20), ""))
			GUI.FocusControl("CMTextField");
	}
}
