﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ball_Script : MonoBehaviour {

	private int count_t1, count_t2;
	private Rigidbody rb;

	public Text t1;
	public Text t2;

	// Use this for initialization
	void Start () {
		count_t1 = 0;
		count_t2 = 0;
		rb = GetComponent<Rigidbody> ();
		updateText ();
	}

	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position [2] < -230) {
			++count_t1;
			setBallToCenter ();
		} else if (transform.position [2] > 228) {
			++count_t2;
			setBallToCenter ();
		}
		updateText ();
	}

	void updateText() {
		t1.text = count_t1.ToString ();
		t2.text = count_t2.ToString ();
	}

	void setBallToCenter(){
		transform.position = new Vector3 (0, 5, 0);
		rb.isKinematic = true;
		rb.isKinematic = false;
	}
}
