//
// Timer.cs
//
// Description: Class to make our lives easier instead of using coroutines.
//
// Author:
// 	Ian Girard
//
// Editors:
//
// Copyright (C) Budge Studios, 2014
//
using UnityEngine;
using System.Collections;

public class Timer
{
    #region Members and Properties
    // Public
    public delegate void OnDone();
    public delegate void OnTimerDone(Timer timer);
    public delegate void OnUpdate();

    public OnDone m_OnDone = null;								// Callback when the timer is done
    public OnTimerDone m_OnTimerDone = null;					// Callback when the timer is done with the timer as parameter
    public OnUpdate m_OnUpdate = null;							// Callback when the timer is running its update loop

    // Protected
    protected float m_TimeLeft = 0.0f;							// Current timer left on the timer
    protected float m_DoneTimeOver = 0.0f;						// The time offset when the timer is done
    protected float m_StartTime = 0.0f;							// Time at which the timer started at
    protected bool m_IsPaused = false;							// Is the timer currently paused or not
    protected bool m_IsStarted = false;							// Is the timer started or not (set to false once it's done and when Stop is called)
    protected bool m_IsHandlingPauseManager = false;			// Whether the timer needs to pause with the PauseManager
    protected bool m_IsDone = false;							// Is the timer done

    // Private

    // Properties
    public bool IsStarted
    {
        get
        {
            return m_IsStarted;
        }
    }

    public bool IsPaused
    {
        get
        {
            return m_IsPaused;
        }
    }

    public bool IsDone
    {
        get
        {
            return m_IsDone;
        }
    }

    public float TimeLeft
    {
        get
        {
            return m_TimeLeft;
        }
    }

    public float TimeSpent
    {
        get
        {
            return m_StartTime - m_TimeLeft;
        }
    }

    public float StartTime
    {
        get { return m_StartTime; }
        set { m_StartTime = value; }
    }

    protected virtual float DeltaTime
    {
        get { return Time.deltaTime; }
    }
    /// <summary>
    /// A ratio between 0 and 1 representing the time left over the initial time.
    /// </summary>
    public float Ratio
    {
        get
        {
            if (m_StartTime == 0)
            {
                return 1;
            }
            else
            {
                return Mathf.Clamp01(1.0f - (m_TimeLeft / m_StartTime));
            }
        }
    }

    public bool IsHandlingPauseManager
    {
        get
        {
            return m_IsHandlingPauseManager;
        }
        set
        {
            m_IsHandlingPauseManager = value;
        }
    }

    public float DoneTimeOver
    {
        get { return m_DoneTimeOver; }
    }
    #endregion

    /// <summary>
    /// Default constructor for the timer.
    /// </summary>
    public Timer(float time = 0.0f)
    {
        m_StartTime = time;
        m_TimeLeft = m_StartTime;
        m_DoneTimeOver = 0.0f;
    }

    ~Timer()
    {
        m_OnDone = null;
        m_OnTimerDone = null;
        m_OnUpdate = null;
    }

    #region Public API
    /// <summary>
    /// Starts the timer with the time set in the timer.
    /// </summary>
    public void Start()
    {
        Start(m_StartTime);
    }

    /// <summary>
    /// Starts the timer from the start. Acts as a restart.
    /// </summary>
    public void Start(float time)
    {
        m_IsDone = false;
        m_IsPaused = false;
        m_IsStarted = true;
        m_StartTime = time;
        m_TimeLeft = m_StartTime;
        m_DoneTimeOver = 0.0f;
    }

    public void Stop()
    {
        m_IsStarted = false;
        m_IsDone = false;
        m_TimeLeft = m_StartTime;
    }

    public void Pause()
    {
        m_IsPaused = true;
    }

    public void Resume()
    {
        m_IsPaused = false;

        // Automatically start the timer if it wasn't started
        if (!m_IsStarted)
        {
            Start();
        }
    }

    public void Restart()
    {
        Start();
    }

    /// <summary>
    /// Resets the timer to the start but doesn't start it
    /// </summary>
    public void Reset()
    {
        m_IsDone = false;
        m_IsPaused = false;
        m_IsStarted = false;
        m_TimeLeft = m_StartTime;
        m_DoneTimeOver = 0.0f;
    }

    /// <summary>
    /// Call it every frame in the Update of a MonoBehaviour.
    /// </summary>
    public void Update()
    {
        if (!m_IsStarted || m_IsPaused || (m_IsHandlingPauseManager))
        {
            return;
        }

        m_TimeLeft -= DeltaTime;
        if (m_TimeLeft <= 0.0f)
        {
            m_DoneTimeOver = -m_TimeLeft;

            m_TimeLeft = 0.0f;
            m_IsStarted = false;
            m_IsDone = true;

            if (m_OnDone != null)
            {
                m_OnDone();
            }

            if (m_OnTimerDone != null)
            {
                m_OnTimerDone(this);
            }
        }
        else if (m_OnUpdate != null)
        {
            m_OnUpdate();
        }
    }
    #endregion

    #region Protected API
    #endregion
}
