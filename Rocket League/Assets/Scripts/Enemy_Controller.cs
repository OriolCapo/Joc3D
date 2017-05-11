using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour {

	public GameObject ball;
	public float speed = 10.0f;

	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 pos_ball = ball.transform.position;
		Vector3 offset = pos_ball - transform.position;
		offset = new Vector3 (offset [0], 0, offset [2]);
		rb.AddForce (offset * speed, ForceMode.Force);
	}
}
