// by @torahhorse

// Instructions:
// Place on player. OnBelowLevel will get called if the player ever falls below

using UnityEngine;
using System.Collections;

public class CheckIfAboveLevel : MonoBehaviour
{
	public float resetAboveThisY = 100f;
	public bool fadeInOnReset = true;
	
	private Vector3 startingPosition;
	
	void Awake()
	{
		startingPosition = transform.position;
	}
	
	void Update ()
	{
		if( transform.position.y > resetAboveThisY )
		{
			OnBelowLevel();
		}
	}
	
	private void OnBelowLevel()
	{
		Debug.Log("Player fell below level");
		Carrito.instance.rigidbody.velocity = Vector3.zero;
		Carrito.instance.rigidbody.angularVelocity = Vector3.zero;

		// Player.instance.GetComponent<Rigidbody>().velocity = Vector3.zero;
		// Player.instance.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
	
		// reset the player
		transform.position = startingPosition;
		
		if( fadeInOnReset )
		{
			// see if we already have a "camera fade on start"
			CameraFadeOnStart fade = GameObject.Find("Main Camera").GetComponent<CameraFadeOnStart>();
			if( fade != null )
			{
				fade.Fade();
			}
			else
			{
				Debug.LogWarning("CheckIfBelowLevel couldn't find a CameraFadeOnStart on the main camera");
			}
		}
		
		// alternatively, you could just reload the current scene using this line:
		//Application.LoadLevel(Application.loadedLevel);
	}
}
