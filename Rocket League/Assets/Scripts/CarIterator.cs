using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarIterator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		MeshCollider[] meshColliders = gameObject.GetComponentsInChildren<MeshCollider>(true) as MeshCollider[];

		foreach (MeshCollider mc in meshColliders) {
			//mc.convex = true;
		}

		/*int children = transform.childCount;
		for (int i = 0; i < children; ++i){
			Transform child = transform.GetChild (i);
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
