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
	public GameObject tweenTarget;
	public UILabel SongTitleText;
	public UILabel SingerText;
    public UILabel ChorusText;
    public UILabel DanceText;

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
	}

	private void PlayTitleTween()
	{
		m_Tween = tweenTarget.AddComponent<TweenPosition>();
		m_Tween.AddOnFinished(RemoveTweenOnFinish);
		m_Tween.from = new Vector3(0, 300, 0);
		m_Tween.to = Vector3.zero;
		m_Tween.PlayForward();
	}

	private void PlayAdTween()
	{
		m_Tween = tweenTarget.AddComponent<TweenPosition>();
		m_Tween.AddOnFinished(RemoveTweenOnFinish);
		m_Tween.from = Vector3.zero;
		m_Tween.to = new Vector3(0, 1108, 0);
		m_Tween.PlayForward();
	}

	private void Update()
	{
		if(Input.GetKeyDown(KeyCode.U))
		{
			PlayTitleTween();
		}
		else if(Input.GetKeyDown(KeyCode.A))
		{
			//PlayAdTween();
		}
		if(stringToEdit.EndsWith("t"))
		{
			char[] trim = {'t'};
			LoadSongText(stringToEdit.Trim(trim));
			PlaySingerTween();
			stringToEdit = "";
		}
	}

	private void RemoveTweenOnFinish()
	{
		if(tweenTarget.GetComponent<TweenPosition>() != null)
		{
			Destroy(tweenTarget.GetComponent<TweenPosition>());
		}
	}

	private void LoadSongText(string trackNumber)
	{
		XmlDocument document = new XmlDocument();
		document.Load(Application.streamingAssetsPath + "/songlistspectacle.xml");

		int songNumber = 0;

		foreach (XmlNode node in document.GetElementsByTagName("Song"))
		{
			if (node.Attributes["Number"].Value == trackNumber)
			{
				SongTitleText.text = node.Attributes["Name"].Value;
				songNumber = Int32.Parse(node.Attributes["Number"].Value);
                SingerText.text = node.Attributes["Singers"].Value;
                ChorusText.text = node.Attributes["Chorus"].Value;
                DanceText.text = node.Attributes["Dance"].Value;
			}
		}
	}

	private string stringToEdit = "";
	private void OnGUI() {
		GUI.SetNextControlName("CMTextField");
		stringToEdit = GUI.TextField(new Rect(100, Screen.height - 20, 20, 20), stringToEdit, 25);
		if (GUI.Button(new Rect(0, Screen.height - 20, 80, 20), ""))
			GUI.FocusControl("CMTextField");
	}
}
