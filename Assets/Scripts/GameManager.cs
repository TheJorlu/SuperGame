using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	public static GameManager instance;
	public int itemsOnList;
	
	public List<List <int>> propsOnScene = new List<List <int>>();
	public List<int> toDoList = new List<int>();

	public bool done;
	public GameObject ending;

	void Awake()
	{
		instance=this;

		for (int i = 0; i < 18; i++)
		{
		    List<int> sublist = new List<int>();
	
			sublist.Add(0);

		    propsOnScene.Add(sublist);
		}
	}

	IEnumerator Start()
	{
		yield return new WaitForSeconds(.1f);
		GenerateList();
	}

	void GenerateList()
	{
		for(int i=0; i < itemsOnList; i++)
		{
			var x = Random.Range(0, propsOnScene.Count);

			if(propsOnScene[x][0] > 0)
			{
				toDoList.Add(x);
				propsOnScene[x][0]--;
			}
		}

		HUDManager.instance.SetupHUD();		
	}

	public void CheckForGoal(int thingIndex)
	{
		Debug.Log("Thing class: " + thingIndex);

		for(int i=0; i < toDoList.Count; i++)
		{
			if(toDoList[i] == thingIndex)
			{
				Debug.Log("Object position: " + i);
				Debug.Log("Object in list: " + toDoList[i]);

				toDoList.RemoveAt(i);
				Debug.Log(toDoList.Count + " Items left");

				HUDManager.instance.MarkItem(i);
				break;
			}
		}
		if(toDoList.Count <= 0)
		{
			done = true;
		}
	}
}
