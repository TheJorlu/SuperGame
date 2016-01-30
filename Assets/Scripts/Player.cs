using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public static Player instance;

	public GameObject carritoCam;

	GameObject heldObject;
	bool holdingObject;

	void Awake(){instance = this;}

	void Update () 
	{
		ListenToInput();
	}
	
	void ListenToInput()
	{
		if(Input.GetMouseButtonDown(0))
		{
			if(!holdingObject)
			{
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		        RaycastHit hit;

		        if (Physics.Raycast(ray, out hit, 3)) 
		        {
		            if(hit.transform.tag == "Grabbable" || hit.transform.tag == "Carrito")
		            {
		            	GrabStuff(hit.transform.gameObject);
		            }
		        }
		    }
		}
		if(Input.GetMouseButtonUp(0))
		{
			if(holdingObject)
			{
				ThrowStuff();
			}
		}
	}

	void GrabStuff(GameObject thing)
	{
    	heldObject = thing;

    	if(heldObject.tag != "Carrito")
    	{
    		heldObject.GetComponent<Thing>().AttachToObject(transform.GetChild(0));
    	}
		else
		{
    		heldObject.GetComponent<Carrito>().AttachToObject(transform);
    		carritoCam.SetActive(true);
		}

    	holdingObject = true;
	}
	void ThrowStuff()
	{
		if(heldObject.tag != "Carrito")
		{
			heldObject.GetComponent<Thing>().ThrowSelf(Camera.main.transform.forward * 1000);
		}
		else
		{
			heldObject.transform.parent = null;
			carritoCam.SetActive(false);
		}

		holdingObject = false;
		heldObject = null;
	}
}
