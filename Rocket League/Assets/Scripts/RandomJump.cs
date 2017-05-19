using UnityEngine;
using System.Collections;

public class RandomJump : MonoBehaviour {
	
	public float forceMagnitude = 100.0f;

	private Rigidbody rb;

	void Start() {
		rb = GetComponent<Rigidbody> ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKeyDown (KeyCode.Space)) {
			forceMagnitude *= (rb.velocity [2]/20);
			rb.AddForce (forceMagnitude * transform.up, ForceMode.Impulse);
			rb.AddForce (2*forceMagnitude * gameObject.transform.forward, ForceMode.Impulse);

			Vector3 x_axis = new Vector3 (transform.forward[2], transform.forward[1], transform.forward[0]);
			rb.AddTorque (forceMagnitude/5 * x_axis, ForceMode.Impulse);
		}
		//print (transform.position);
	}
}
