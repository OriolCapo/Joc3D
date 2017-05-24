using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour {

	public float speed = 1000.0f;
	public int goal = 1;
	public WheelCollider[] wheelColliders;

	private GameObject ball;
	private Rigidbody rb;
	private Vector3 positionBehindBall;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		ball = GameObject.Find ("Ball");
	}

	void FixedUpdate () {
		updatePosition ();
		if (shallGoBehindBall ()) {
			goBehindBall ();
		} else {
			goToHitBall ();
		}
	}

	void updatePosition() {
		Vector3 goalPosition;
		if(goal ==1)
			goalPosition = new Vector3 (0,0,170);
		else 
			goalPosition = new Vector3 (0,0,-170);
		Vector3 direction = Vector3.Normalize(goalPosition - ball.transform.position);
		positionBehindBall = ball.transform.position - (60 * direction);
	}

	bool shallGoBehindBall(){
		Vector3 currPos = transform.position;
		Vector3 ballPos = ball.transform.position;
		if (currPos.z >= ballPos.z) {
			return true; 
		}
		if(Mathf.Abs (ballPos.x - currPos.x) > 50) {
			return true;
		}
		else {
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
		posToGo = posToGo.normalized;
		rb.AddForce (transform.forward * speed);
	}

}
