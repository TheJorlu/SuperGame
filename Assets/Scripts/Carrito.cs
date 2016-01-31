using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Carrito : Thing 
{
	public static Carrito instance;
	public Transform box;

	public List<Thing> things = new List<Thing>();

	void Awake(){instance = this;}

	// void LateUpdate()
	// // {
	// // 	if(this.transform.position.y < 0.5f)
	// // 	{
	// // 		rigidbody.velocity = Vector3.zero;
	// // 		rigidbody.angularVelocity = Vector3.zero;
	// // 		rigidbody.AddForce(Vector3.up);
	// // 	}
	// }

	public override void AttachToObject(Transform parent)
	{
		transform.SetParent(parent);
		//transform.localPosition = new Vector3(0,-.5f,1.4f);
		foreach  (Thing thing in things) 
		{
			thing.gameObject.layer = 8;
		}
	}

	public void AddThing(Thing thing)
	{
		if(!things.Contains(thing))
		{
			things.Add(thing);

			
			thing.rigidbody.isKinematic = true;

			thing.transform.position = box.position;
			thing.transform.parent = box;
		}
	}
}
