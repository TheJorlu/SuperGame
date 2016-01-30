using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Carrito : Thing 
{
	public static Carrito instance;
	public Transform box;

	public List<Thing> things = new List<Thing>();

	void Awake(){instance = this;}

	public override void AttachToObject(Transform parent)
	{
		transform.SetParent(parent);
		transform.localPosition = new Vector3(0,-.5f,1.4f);
	}

	public void AddThing(Thing thing)
	{
		if(!things.Contains(thing))
			things.Add(thing);

		thing.transform.position = box.position;
		thing.transform.parent = box;
	}
}
