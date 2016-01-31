using UnityEngine;
using System.Collections;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(AudioSource))]
public class Thing : MonoBehaviour 
{
	public Objeto objeto;
	public enum Objeto
	{
		Garrafon = 0,
		Vino = 1,
		Tequila = 2,
		Chupe = 3,
		Cereal = 4,
		Galletas = 5,
		Condones = 6,
		Regalo = 7,
		Medicina = 8,
		Leche = 9,
		Chocolate = 10,
		Papas = 11,
		Platano = 12,
		Manzana = 13,
		Naranga = 14,
		Sandia = 15,
		Licor = 16,
		Rompope = 17
	}

	[HideInInspector]
	public bool held;

	void Start()
	{
		GameManager.instance.propsOnScene[(int)objeto][0]++;
	}

	void OnTriggerEnter(Collider col)
	{
		if(col.transform.tag == "CarritoBox" && held)
		{
    		Carrito.instance.AddThing(this);
		}
	}

	void OnCollisionEnter()
	{
		GetComponent<AudioSource>().Play();
	}

	public void AttachToObject(Transform parent)
	{
		GetComponent<Rigidbody>().isKinematic = true;
		gameObject.layer = 8;

		transform.SetParent(parent);
		held = true;
	}

	public void ThrowSelf(Vector3 direction)
	{
		GetComponent<Rigidbody>().isKinematic = false;
		gameObject.layer = 8;

		transform.SetParent(null);
		held = false;

		GetComponent<Rigidbody>().AddForce(direction);
	}
}
