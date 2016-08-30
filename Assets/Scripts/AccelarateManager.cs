using UnityEngine;
using System.Collections;

public class AccelarateManager : MonoBehaviour {

    public ParticleEmitter Left;
    public ParticleEmitter Right;
    public ParticleEmitter Top;
    public ParticleEmitter Bottom;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            if (!Left.emit)
            {
                Left.emit = true;
            }
            else
            {
                Left.emit = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            if (!Right.emit)
            {
                Right.emit = true;
            }
            else
            {
                Right.emit = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            if (!Top.emit)
            {
                Top.emit = true;
            }
            else
            {
                Top.emit = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            if (!Bottom.emit)
            {
                Bottom.emit = true;
            }
            else
            {
                Bottom.emit = false;
            }
        }
        else if (Input.GetKeyUp(KeyCode.Alpha0))
        {
            Left.emit = false;
            Right.emit = false;
            Top.emit = false;
            Bottom.emit = false;
        }
    }
}
