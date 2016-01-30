using UnityEngine;
using System.Collections;

public class CubeScript : MonoBehaviour 
{
	Rigidbody rigidbody;

	void Start()
	{
		rigidbody = GetComponent<Rigidbody>();
	}

	public void AttachToObject(Transform parent)
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
