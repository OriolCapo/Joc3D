using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverMotor : MonoBehaviour {

    public float speed = 90f;
    public float turnSpeed = 5f;
    public float hoverForce = 65f;
    public float hoverHeight = 1.25f;

    private float powerInput;
    private float turnInput;
    private Rigidbody carRigidBody;

	
	void Awake () {
        carRigidBody = GetComponent<Rigidbody>();
	}
	
	void Update () {
        powerInput = Input.GetAxis("Vertical");
        turnInput = Input.GetAxis("Horizontal");
	}

    void FixedUpdate()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, hoverHeight))
        {
            float proportionalHeight = (hoverHeight - hit.distance) /(2* hoverHeight);
            Vector3 appliedHoverForce = Vector3.up * proportionalHeight * hoverForce;

            carRigidBody.AddForce(appliedHoverForce, ForceMode.Acceleration);
        }

        carRigidBody.AddRelativeForce(powerInput * speed, 0f, 0f);
        carRigidBody.AddRelativeTorque(0f, turnInput * turnSpeed, 0f);

    }
}
