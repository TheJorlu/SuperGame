using UnityEngine;
using System.Collections;

public class Bumper : MonoBehaviour 
{
	void OnCollisionEnter(Collision col)
	{
		if(col.transform.tag == "Grabbable")
		{
			col.gameObject.GetComponent<Thing>().ThrowSelf( Random.insideUnitSphere * 1000);
		}
	}
}
