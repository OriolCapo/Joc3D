using UnityEngine;
using System.Collections;

public class RandomJump : MonoBehaviour {
	
	public float forceMagnitude = 100.0f;
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKey(KeyCode.Space))
			gameObject.GetComponent<Rigidbody> ().AddForce (forceMagnitude * Vector3.up, ForceMode.Force);
	}
}
