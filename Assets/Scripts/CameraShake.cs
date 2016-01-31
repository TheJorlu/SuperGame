using UnityEngine;
using System.Collections;
using Kino;

public class CameraShake : MonoBehaviour 
{
	public AnalogGlitch glitch;

	private static CameraShake _instance;
	public static CameraShake instance
	{
        get
        {
            if(_instance == null)
                _instance = GameObject.FindObjectOfType<CameraShake>();
            return _instance;
        }
    }

	private float _amplitude;
	private Vector3 initialPosition;
	private bool isShaking;
	
	IEnumerator Start()
	{
		yield return new WaitForSeconds(1);
		initialPosition = transform.localPosition;
	}
	
	void Update () 
	{
		if(isShaking)
		{
			transform.localPosition = initialPosition + Random.insideUnitSphere * _amplitude;

			glitch.enabled = true;
		}
		else
		{
			glitch.enabled = false;
		}
	}

	public void Shake(float amplitude, float duration)
	{
		_amplitude = amplitude;
		isShaking = true;

		CancelInvoke();
		Invoke("StopShaking", duration);
	}

	public void StopShaking()
	{
		isShaking = false;
	}
}
