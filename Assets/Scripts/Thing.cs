using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Thing : MonoBehaviour 
{
	[HideInInspector]
	public Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.transform.tag == "CarritoBox")
		{
			Player.instance.LetGo();
    		Carrito.instance.AddThing(this);
		}
	}

	void OnTriggerExit(Collider col)
	{
		if(col.transform.tag == "Carrito")
		{
			rigidbody.velocity = Vector3.zero;
    		rigidbody.angularVelocity = Vector3.zero; 
    		Carrito.instance.things.Remove(this);
		}
	}

	public virtual void AttachToObject(Transform parent)
	{
		rigidbody.isKinematic = true;

		transform.SetParent(parent);
	}

	public void ThrowSelf(Vector3 direction)
	{
		rigidbody.isKinematic = false;

		transform.SetParent(null);

		rigidbody.AddForce(direction);
	}
}
