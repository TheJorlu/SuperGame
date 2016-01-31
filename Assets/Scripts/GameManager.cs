using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour 
{
	public static GameManager instance;
	public int itemsOnList;
	
	public List<List <int>> propsOnScene = new List<List <int>>();
	public List<int> toDoList = new List<int>();

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

	void Update()
	{
		if(Input.GetKeyDown(KeyCode.Q))
		{
			for(int i=0; i < propsOnScene.Count; i++)
			{
				for(int j=0; j < propsOnScene[i].Count; j++)
				{
					Debug.Log("Item: " + i + " Cantidad: " + propsOnScene[i][j]);
				}
			}

			GenerateList();
		}
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
	}

	public void CheckForGoal(int thingIndex)
	{
		Debug.Log("Thing class: " + thingIndex);

		for(int i=0; i < toDoList.Count; i++)
		{
			if(toDoList[i] == thingIndex)
			{
				Debug.Log("Object in list: " + i);

				toDoList.Remove(i);
				Debug.Log(toDoList.Count + " Items left");
				break;
			}
		}
	}
}
