using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Carrito : MonoBehaviour 
{
	public static Carrito instance;
	public Transform box;
	public GameObject carritoCam;

	public List<Thing> things = new List<Thing>();

	void Awake(){instance = this;}

	void LateUpdate()
	{
		if(transform.position.y < 0.5f)
		{
			transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
		}
		else if(transform.position.y > 0.55f)
		{
			transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
		}
	}

	void OnMouseDown()
	{
		transform.parent = Player.instance.transform;
		carritoCam.SetActive(true);
	}

	void OnMouseUp()
	{
		transform.parent = null;
		carritoCam.SetActive(false);
	}

	public void AddThing(Thing thing)
	{
		if(!things.Contains(thing))
		{
			things.Add(thing);
			Player.instance.LetGo();
			
			thing.GetComponent<Rigidbody>().isKinematic = true;

			thing.transform.position = box.position;
			thing.transform.parent = box;

			GameManager.instance.CheckForGoal((int)thing.objeto);
		}
	}
}
