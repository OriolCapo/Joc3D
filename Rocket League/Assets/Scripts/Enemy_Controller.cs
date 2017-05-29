using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour {

	public float speed = 10000.0f;
	public WheelCollider[] wheelColliders = new WheelCollider[4];

	private GameObject ball;
	private Rigidbody rb;
	private Vector3 positionBehindBall;
	private Vector3 goalPosition;
	private int team;

	void Start () {
		rb = GetComponent<Rigidbody> ();
		ball = GameObject.Find ("Ball");
		if (name.Substring (0, 3).Equals ("Ene")) {
			goalPosition = new Vector3 (0, 0, 170);
			team = 2;
		} else if (name.Substring (0, 3).Equals ("All")){
			goalPosition = new Vector3 (0, 0, -170);
			team = 1;
		}

	}

	void FixedUpdate () {
		for (int i = 0; i < 4; i++) {
			wheelColliders [i].motorTorque = 25.0f;
		}

		if (PlayerPrefs.GetInt ("onPlay") == 1) {
			updatePosition ();
			if (partialGrounded ()) {
				if (shallGoBehindBall ()) {
					goBehindBall ();
				} else {
					goToHitBall ();
				}
			} else {
				if (transform.up [1] < -0.9f && transform.up [1] > -1.0f) {
					//PlayerPrefs.SetInt ("onPlay", 0);
					transform.Translate (Vector3.up * 2);
					transform.Rotate (transform.forward * 180.0f);
				} else if (transform.position.y < 0) {
					float dist = transform.position.y;
					transform.Translate (Vector3.up * (dist + 1.0f));
				}
			}
		}
	}

	void updatePosition() {
		Vector3 direction = Vector3.Normalize(goalPosition - ball.transform.position);
		positionBehindBall = ball.transform.position - (40 * direction);
	}

	bool shallGoBehindBall(){
		Vector3 currPos = transform.position;
		Vector3 ballPos = ball.transform.position;
		if (team == 2 && (currPos.z >= ballPos.z || Mathf.Abs (ballPos.x - currPos.x) > 50)) {
			return true; 
		} else if (team == 2)
			return false;
		if (team == 1 && (currPos.z < ballPos.z || Mathf.Abs (ballPos.x - currPos.x) > 50)) {
			return true; 
		} else if (team == 1)
			return false;
		//Never happens
		else return true;
	}

	bool partialGrounded(){
		bool b = false;
		for (int i = 0; i < 4; i++)
			if (wheelColliders [i].isGrounded)
				b = true;
		return b;
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

	public void restartWheels(){
		for (int i = 0; i < 4; i++){
			wheelColliders[i].motorTorque = 0;
			wheelColliders[i].steerAngle = 0;
		}
		setStiffness (0.0001f);
	}

	public void setStiffness(float value){
		for (int i = 0; i < 4; i++){
			WheelFrictionCurve frictionCurve = wheelColliders[i].forwardFriction;
			frictionCurve.stiffness = value;//whatver you want
			wheelColliders[i].forwardFriction = frictionCurve;
		}
	}

}
