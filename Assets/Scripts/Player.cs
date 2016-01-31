using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public static Player instance;

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
		        
		        LayerMask mask = 8;
		        mask = ~mask;

		        if (Physics.Raycast(ray, out hit, 5, mask)) 
		        {
		            if(hit.transform.tag == "Grabbable")
		            {
		            	heldObject = hit.transform.gameObject;

		            	heldObject.GetComponent<Thing>().AttachToObject(transform.GetChild(0));
		            }
		        }
		    }
		}
		if(Input.GetMouseButtonUp(0))
		{
			if(heldObject != null)
			{
				heldObject.GetComponent<Thing>().ThrowSelf(Camera.main.transform.forward * 1000);

				heldObject = null;
			}
		}
	}

	public void LetGo()
	{
		heldObject.transform.parent = null;
		holdingObject = false;
		heldObject = null;
	}
}
