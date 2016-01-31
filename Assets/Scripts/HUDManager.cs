using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HUDManager : MonoBehaviour 
{
	public static HUDManager instance;

	public Sprite[] objetosSprites;
	public Image[] itemsToGet;
	public List<GameObject> marcas;

	void Awake(){instance=this;}

	public void SetupHUD()
	{
		for(int i=0; i < itemsToGet.Length; i++)
		{
			itemsToGet[i].sprite = objetosSprites[GameManager.instance.toDoList[i]];
		}
	}

	public void MarkItem(int index)
	{
		marcas[index].SetActive(true);
		marcas.RemoveAt(index);
	}
}
