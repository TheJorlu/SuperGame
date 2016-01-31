using UnityEngine;
using System.Collections;

public class Estante : MonoBehaviour 
{
	public Transform[] nodes;
	public GameObject[] productsPrefabs;

	void Start()
	{
		foreach(Transform node in nodes)
		{
			int randomNum = Random.Range(0, productsPrefabs.Length);

			var obj = (GameObject)Instantiate(productsPrefabs[randomNum], node.position, Quaternion.identity);

			obj.transform.parent = node;
			obj.transform.localRotation = Quaternion.Euler(Vector3.zero);
		}
	}
}
