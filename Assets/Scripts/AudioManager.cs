using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour 
{
	public static AudioManager instance;

	public AudioClip[] sfx;

	void Awake(){instance=this;}
}
