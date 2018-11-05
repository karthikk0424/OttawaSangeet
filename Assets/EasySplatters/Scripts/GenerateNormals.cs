/*===============================================================
Developer:  Karthik Karunakaran
Company:    Vector3Games
================================================================*/

using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GenerateNormals : MonoBehaviour {
    #region singleton
    #endregion singleton

    #region events and delegates
    #endregion events and delegates

    //const

    //public
    public GameObject ExplosionParticles;
    public Color m_Green = Color.green;
    public Color m_Red = Color.red;
    public Color m_Yellow = Color.yellow;
    public Color m_Blue = Color.blue;
    public Color m_Black = Color.black;
    public Color m_White = Color.white;

    //protected

    //private
    private Color m_CurrentColor;

    /// <summary>
    /// Green
    /// Red
    /// Yellow
    /// Blue
    /// Black
    /// White
    /// </summary>

    private float minx = 0;
    private float maxx = 0;
    private float miny = 0;
    private float maxy = 0;

    #region properties
    #endregion properties

    #region structs
    #endregion structs

    #region Unity API methods

    private List<Vector3> m_VectorsList = new List<Vector3>();

    private void Start()
    {
        minx = GetComponent<BoxCollider2D>().bounds.min.x;
        miny = GetComponent<BoxCollider2D>().bounds.min.y;

        maxx = GetComponent<BoxCollider2D>().bounds.max.x;
        maxy = GetComponent<BoxCollider2D>().bounds.max.y;
        m_CurrentColor = Color.green;
        StartCoroutine(StartSplatterSystem());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            m_CurrentColor = m_Green;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            m_CurrentColor = m_Red;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            m_CurrentColor = m_Yellow;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            m_CurrentColor = m_Blue;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            m_CurrentColor = m_Black;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            m_CurrentColor = m_White;
        }
    }

    #endregion Unity API methods

    #region public methods
    #endregion public methods

    #region protected methods
    #endregion protected methods

    #region private methods
    private void ResetSplat()
    {
        StopCoroutine(StartSplatterSystem());
        StartCoroutine(StartSplatterSystem());
    }
    private IEnumerator StartSplatterSystem()
    {
        m_VectorsList.Clear();
        for (int i = 0; i < Random.Range(15,30) ; i++)
        {
            m_VectorsList.Add(RandomPointOnPlane());
        }

        foreach (Vector3 position in m_VectorsList)
        {
            if (Random.Range(1, 3) == 1)
            {
                yield return new WaitForSeconds(.5f);
            }
            
            SpawnSplatter(position);
        }
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(StartSplatterSystem());
    }
    private Vector3 RandomPointOnPlane()
    {
        Vector3 randomPoint = new Vector3(Random.Range(minx, maxx), Random.Range(miny, maxy), 0);
        return randomPoint;
    }

    private void SpawnSplatter(Vector3 position)
    {
        //Spawn some particles
        var explosionParticles = Instantiate(ExplosionParticles);
        var explosionScript = explosionParticles.GetComponent<ExplosionParticles>();
        explosionScript.SetColor(m_CurrentColor);
        explosionParticles.transform.position = position;

        //Leave a Splatter
        SplatterSystem.Instance.LeaveSplatter(position, m_CurrentColor);
    }
    #endregion private methods
}