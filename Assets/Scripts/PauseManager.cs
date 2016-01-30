using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseManager : MonoBehaviour 
{
	public Image pausePanel;
	public MonoBehaviour[] scriptsToDisable;

	private bool isPaused;
	public float timer = 5;

	void Start()
	{
		Time.timeScale = 1;
	}

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(!isPaused)
			{
				isPaused = true;
				pausePanel.color = new Color(1,1,1,.5f);

				Time.timeScale = 0;
			}
			else
			{
				isPaused = false;
				pausePanel.color = new Color(1,1,1,0);

				Time.timeScale = 1;
			}
		}
		else if(Input.GetKeyUp(KeyCode.Escape))
		{
			timer = 5;
		}

		if(Input.GetKey(KeyCode.Escape))
		{
			timer -= Time.fixedDeltaTime;
			pausePanel.color = new Color(1,1,1, pausePanel.color.a + (Time.fixedDeltaTime/10));

			if(timer <= 0)
			{
				Application.LoadLevel("Menu");
			}
		}	
	}
}
