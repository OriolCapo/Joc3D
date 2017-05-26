using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCarControler : MonoBehaviour {

	public WheelCollider[] wheelColliders = new WheelCollider[4];
	public GameObject[] wheelMeshes = new GameObject[4];
	public float speed = 25.0f;

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
		float accel = Input.GetAxis ("Vertical");
		float torque = Input.GetAxis ("Horizontal");

		for (int i = 0; i < 4; i++)
		{
			Quaternion quat;
			Vector3 position;
			wheelColliders[i].GetWorldPose(out position, out quat);
			wheelMeshes[i].transform.position = position;
			wheelMeshes[i].transform.rotation = quat;
		}
		torque = Mathf.Clamp(torque, -1, 1);
		float rot = torque*50;
		wheelColliders[0].steerAngle = rot;
		wheelColliders[1].steerAngle = rot;


		accel = Mathf.Clamp(accel, -1, 1);
		float thrustTorque = accel * speed;
		for (int i = 0; i < 4; i++) {
			//wheelColliders [i].attachedRigidbody.AddTorque (accel*accelSpeed, 1, 1);
			wheelColliders[i].motorTorque = thrustTorque;
		}
		rb.AddForce (accel * speed  * transform.forward);
	}
}
