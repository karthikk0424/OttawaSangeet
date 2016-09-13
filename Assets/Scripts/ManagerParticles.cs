using UnityEngine;
using System.Collections;

public class ManagerParticles : MonoBehaviour {
	public ParticleEmitter Green;
	public ParticleEmitter Blue;
	public ParticleEmitter Red;
    public ParticleEmitter Orange;
	public GameObject Firework;

	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Alpha1))
		{
			if(!Green.emit)
			{
				Green.emit = true;
			}
			else
			{
				Green.emit = false;
			}
		}
		else if(Input.GetKeyUp(KeyCode.Alpha2))
		{
			if(!Red.emit)
			{
				Red.emit = true;
			}
			else
			{
				Red.emit = false;
			}
		}
		else if(Input.GetKeyUp(KeyCode.Alpha3))
		{
			if(!Blue.emit)
			{
				Blue.emit = true;
			}
			else
			{
				Blue.emit = false;
			}
		}
        else if (Input.GetKeyUp(KeyCode.Alpha4))
        {
            if (!Orange.emit)
            {
                Orange.emit = true;
            }
            else
            {
                Orange.emit = false;
            }
        }
		else if(Input.GetKeyUp(KeyCode.Alpha0))
		{
			Green.emit = false;
			Red.emit = false;
			Blue.emit = false;
            Orange.emit = false;
            Firework.GetComponent<ParticleSystem>().Stop();
		}

		else if(Input.GetKeyUp(KeyCode.Alpha5))
		{
            if (!Firework.GetComponent<ParticleSystem>().isPlaying)
            {
                Firework.GetComponent<ParticleSystem>().Play();   
            }
            else
            {
                Firework.GetComponent<ParticleSystem>().Stop();
            }
		}
	}
}
