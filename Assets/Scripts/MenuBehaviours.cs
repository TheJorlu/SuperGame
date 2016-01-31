using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuBehaviours : MonoBehaviour {

	public GameObject MainPanel;
	public GameObject CreditsPanel;

	void Awake()
	{
		Cursor.visible = true;
		Cursor.lockState = CursorLockMode.None;
	}

	public void LoadMainGame()
	{
		Application.LoadLevelAsync("Main");
	}

	public void ExitGame()
	{
		Application.Quit();
	}

	public void GoToCredits()
	{
		MainPanel.SetActive(false);
		CreditsPanel.SetActive(true);
	}

	public void GoToMain()
	{
		MainPanel.SetActive(true);
		CreditsPanel.SetActive(false);
	}
}
