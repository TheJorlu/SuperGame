using UnityEngine;
using System.Collections;

public class ThrowStuff : MonoBehaviour {

	GameObject heldObject;
	bool holdingObject;
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetMouseButtonDown(0) && !holdingObject)
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
	        RaycastHit hit;

	        if (Physics.Raycast(ray, out hit, 5)) 
	        {
	            if(hit.transform.tag == "Cubo")
	            {
	            	heldObject = hit.transform.gameObject;

	            	heldObject.GetComponent<CubeScript>().AttachToObject(transform);
	            	holdingObject = true;
	            }
	        }
		}
		else if(Input.GetMouseButtonDown(0) && holdingObject)
		{
			heldObject.GetComponent<CubeScript>().ThrowSelf(Camera.main.transform.forward * 1000);

			holdingObject = false;
			heldObject = null;
		}
	}
	
}
