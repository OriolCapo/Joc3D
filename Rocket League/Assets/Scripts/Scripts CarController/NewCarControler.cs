using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCarControler : MonoBehaviour {
	
	public WheelCollider[] wheelColliders = new WheelCollider[4];
	public GameObject[] wheelMeshes = new GameObject[4];
	public float speed = 2500.0f;

	private Quaternion[] wheelMeshLocalRotations;
	private Rigidbody rb;

	// Use this for initialization
	void Start () {
		wheelMeshLocalRotations = new Quaternion[4];
		for (int i = 0; i < 4; i++)
		{
			wheelMeshLocalRotations[i] = wheelMeshes[i].transform.localRotation;
		}
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (PlayerPrefs.GetInt ("onPlay") == 1) {
			float accel = Input.GetAxis ("Vertical");
			float torque = Input.GetAxis ("Horizontal");

			for (int i = 0; i < 4; i++) {
				Quaternion quat;
				Vector3 position;
				wheelColliders [i].GetWorldPose (out position, out quat);
				wheelMeshes [i].transform.position = position;
				wheelMeshes [i].transform.rotation = quat;
			}
			torque = Mathf.Clamp (torque, -1, 1);
			float rot = torque * 30;
			wheelColliders [0].steerAngle = rot;
			wheelColliders [1].steerAngle = rot;


			accel = Mathf.Clamp (accel, -1, 1);
			float thrustTorque = accel * speed;
			for (int i = 0; i < 4; i++) {
				//wheelColliders [i].attachedRigidbody.AddTorque (accel*accelSpeed, 1, 1);
				wheelColliders [i].motorTorque = thrustTorque;
			}
			AddDownForce ();
		}
	}

	private void AddDownForce()
	{
		wheelColliders[0].attachedRigidbody.AddForce(-transform.up*100*
			wheelColliders[0].attachedRigidbody.velocity.magnitude);

		wheelColliders[1].attachedRigidbody.AddForce(-transform.up*100*
			wheelColliders[1].attachedRigidbody.velocity.magnitude);
	}
	/*
	public float maxTorque;
	public float jumpHeight;
	public float maxBrake;
	public Transform centerOfMass;

	public WheelCollider[] wheelColliders = new WheelCollider[4];
	public Transform[] tireMeshes = new Transform[4];

	//private Movement m;
	private Rigidbody rigidBody;
	private string state;
	private float t;

	// Use this for initialization
	void Start()
	{
		rigidBody = GetComponent<Rigidbody>();
		rigidBody.centerOfMass = centerOfMass.localPosition;
		//m = GameObject.FindGameObjectWithTag("Movement").GetComponent<Movement> ();
		state = "static";
		t = Time.time - 2.5f;
	}

	// Update is called once per frame
	void Update () {
		UpdateMeshesPositions();
		if (Input.GetKeyDown (KeyCode.Space) && Grounded(wheelColliders))
			Jump (jumpHeight,rigidBody);
	}

	void FixedUpdate () {
		float directionAngle = Input.GetAxis("Horizontal");
		float directionAcc = Input.GetAxis("Vertical");
		float steer = 5f;
		Rotate (steer, wheelColliders, directionAngle);
		if (state == "static") {
			if (directionAcc == -1) {
				if (Time.time - 2.5 >= t) {
					maxBrake = 0;
					maxTorque /= 2;
					state = "backward";
				}
			} else if (directionAcc == 1) {
				maxBrake = 0;
				maxTorque *= 2;
				state = "forward";
			}
		} else if (state == "backward") {
			if (directionAcc != -1 && directionAcc != 1) {
				maxBrake = 10000;
				maxTorque *= 2;
				state = "static";
			}
		} else {
			if (directionAcc != -1 && directionAcc != 1) {
				maxBrake = 80000;
				maxTorque /= 2;
				state = "static";
				t = Time.time;
			}
		}
		Accelerate (maxTorque,wheelColliders,directionAcc);
		Brake (maxBrake,wheelColliders);

	}

	private void UpdateMeshesPositions() {
		for (int i = 0; i < 4; ++i) {
			Quaternion quat;
			Vector3 pos;
			wheelColliders [i].GetWorldPose (out pos, out quat);
			tireMeshes [i].position = pos;
			tireMeshes [i].rotation = quat;
		}
	}

	public void Jump() {
		Jump (jumpHeight,rigidBody);
	}

	public void Accelerate (float acc, WheelCollider[] wc, float direction) {
		for (int i = 0; i < 4; ++i) {
			wc [i].motorTorque = direction * acc;
		}
	}

	public void Brake (float br, WheelCollider[] wc) {
		for (int i = 0; i < 4; ++i) {
			wc [i].brakeTorque = br;
		}
	}

	public void Jump (float jmp, Rigidbody rb) {
		rb.AddForce (Vector3.up * jmp,ForceMode.Acceleration);
	}

	public void Rotate (float rt, WheelCollider[] wc, float direction) {
		float finalAngle = direction * rt;
		wc[0].steerAngle = finalAngle;
		wc[1].steerAngle = finalAngle;
	}

	public bool Grounded(WheelCollider[] wc) {
		return (wc [0].isGrounded && wc [1].isGrounded && wc [2].isGrounded && wc [3].isGrounded);
	}
	*/
}
