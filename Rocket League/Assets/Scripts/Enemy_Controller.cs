using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour {

	private GameObject ball;
	public float speed = 1000.0f;

	private Rigidbody rb;
	private LineRenderer laserLine;

	private Vector3 positionBehindBall;

	private bool goHit;
	private bool goBehind;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		laserLine = GetComponent<LineRenderer> ();
		ball = GameObject.Find ("Ball");
		goHit = false;
		goBehind = true;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		updatePosition ();
		if (shallGoBehindBall ()) {
			goBehindBall ();
		} else {
			goToHitBall ();
		}
			

		//rb.AddForce (transform.forward * speed);
		//print (transform.position);
		/*
		Vector3 lineStart = new Vector3(transform.position.x, transform.position.y+5, transform.position.z);
		Vector3 lineEnd = lineStart + (transform.forward * 500f);// + new Vector3(0,10,0);
		laserLine.SetPosition (0, lineStart);
		laserLine.SetPosition (1, lineEnd);

		RaycastHit hit;
		if (Physics.Raycast (lineStart, transform.forward, out hit, 500f)) {
			if (hit.rigidbody != null && hit.transform.CompareTag ("Ball")) {
				rb.AddForce (transform.forward * speed);
				//Debug.Log ("avança");
			} else {
				
				rb.AddForce (transform.forward * 100);
			}
		}
		*/
		//Debug.Log (transform.position);
	}

	void updatePosition() {
		Vector3 goalPosition = new Vector3 (0,0,170);
		Vector3 direction = Vector3.Normalize(goalPosition - ball.transform.position);
		positionBehindBall = ball.transform.position - (60 * direction);
	}

	bool shallGoBehindBall(){
		Vector3 currPos = transform.position;
		Vector3 ballPos = ball.transform.position;
		if (currPos.z >= ballPos.z) {
			//Debug.Log ("GO BEHIND Z<Z   " + rb.velocity);
			return true; 
		}
		if(Mathf.Abs (ballPos.x - currPos.x) > 50) {
			//Debug.Log ("GO BEHIND X--X   " + rb.velocity);
			return true;
		}
		else {
			//Debug.Log ("GO HIT   " + rb.velocity);
			goBehind = false;
			return false;
		}
	}

	void goBehindBall(){
		Vector3 pos = transform.position;
		Vector3 ballPos = ball.transform.position;
		Vector3 offset;

		if (pos.x < ballPos.x) offset = new Vector3 (-20, 0, 0);
		else offset = new Vector3 (20, 0, 0);

		Vector3 meta = (positionBehindBall + offset) - pos;

		transform.rotation = Quaternion.Slerp(transform.rotation, 
								Quaternion.LookRotation(meta), 
								Time.deltaTime*3);
		
		meta = meta.normalized;
		rb.AddForce (transform.forward * speed);

	}

	void goToHitBall(){
		Vector3 pos = transform.position;
		Vector3 ballPos = ball.transform.position;
		Vector3 posToGo = ballPos - pos;

		transform.rotation = Quaternion.Slerp(transform.rotation, 
								Quaternion.LookRotation(posToGo), 
								Time.deltaTime*3);
		//Vector3.Normalize (posToGo);
		posToGo = posToGo.normalized;
		rb.AddForce (transform.forward * speed);
	}

}
