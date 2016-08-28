//
// ParticleColorChanger.cs
//
// Description:
//  
//
// Author:
//  Eric Robitalle
//
// Copyright (C) Budge Studios Inc., 2015

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ParticleColorChanger : MonoBehaviour 
{
	#region Members and Properties
	// constants
	
	// enums
	
	// public
	
	// protected

	// private
	private ParticleSystem[] m_Particles;
	private Timer m_ColorSwapTimer = new Timer();
	private int m_CurrentColorIndex;

	[SerializeField] private bool m_IsRandom;
	[SerializeField] private float m_TimeBetweenSwitches;
	[SerializeField] private List<Color> m_Colors = new List<Color>();

	// properties
	#endregion
	
	#region Unity API
	private void Awake()
	{
		m_Particles = GetComponentsInChildren<ParticleSystem>(true);

		if (m_TimeBetweenSwitches > 0)
		{
			m_ColorSwapTimer.m_OnDone = SwapColor;
			m_ColorSwapTimer.IsHandlingPauseManager = true;
			m_ColorSwapTimer.Start(m_TimeBetweenSwitches);
		}
	}

	private void Update()
	{
		if (m_ColorSwapTimer != null)
		{
			m_ColorSwapTimer.Update();
		}
	}

	private void OnDestroy()
	{
		m_ColorSwapTimer.Stop();
		m_ColorSwapTimer.m_OnDone = null;
	}
	#endregion
	
	#region Public API
	#endregion
	
	#region Protected Methods
	#endregion

	#region Private Methods
	private void SwapColor()
	{
		if (m_IsRandom)
		{
			m_CurrentColorIndex = Random.Range(0, m_Colors.Count);
		}
		else
		{
			m_CurrentColorIndex = (m_CurrentColorIndex + 1) % m_Colors.Count;
		}

		foreach (ParticleSystem ps in m_Particles)
		{
			ps.startColor = m_Colors[m_CurrentColorIndex];
		}

		m_ColorSwapTimer.Restart();
	}
	#endregion
}
