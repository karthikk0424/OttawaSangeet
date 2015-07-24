using UnityEngine;
using System.Collections;

public class MainScreenManager : MonoBehaviour 
{
	private TweenPosition m_Tween;
	public GameObject tweenTarget;

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
		if(Input.GetKeyDown(KeyCode.K))
		{
			PlaySingerTween();
		}
		else if(Input.GetKeyDown(KeyCode.U))
		{
			PlayTitleTween();
		}
		else if(Input.GetKeyDown(KeyCode.A))
		{
			PlayAdTween();
		}
	}

	private void RemoveTweenOnFinish()
	{
		if(tweenTarget.GetComponent<TweenPosition>() != null)
		{
			Destroy(tweenTarget.GetComponent<TweenPosition>());
		}
	}
}
