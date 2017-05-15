using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour {

	public GameObject ball;
	public float speed = 10.0f;

	private Rigidbody rb;
	private LineRenderer laserLine;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		laserLine = GetComponent<LineRenderer> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		transform.rotation = 
			Quaternion.Slerp(transform.rotation, 
							Quaternion.LookRotation(ball.transform.position - transform.position), 
							Time.deltaTime*3);
		//transform.position += transform.forward * Time.deltaTime * speed;
		Vector3 lineStart = new Vector3(transform.position.x, transform.position.y+2, transform.position.z);
		Vector3 lineEnd = lineStart + (transform.forward * 200) + new Vector3(0,10,0);
		laserLine.SetPosition (0, lineStart);
		laserLine.SetPosition (1, lineEnd);

		RaycastHit hit;
		if (Physics.Raycast (lineStart, transform.forward, out hit, 200f)) {
			if (hit.rigidbody != null && hit.transform.CompareTag ("Ball")) {
				rb.AddForce (transform.forward * speed);
				Debug.Log ("avança");
			} else {
				rb.AddForce (transform.forward * 100);
			}
		}

		//Debug.Log (transform.position);
	}
}
