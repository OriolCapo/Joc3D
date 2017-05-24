using System;
using UnityEngine;

public class Bots_Controller : MonoBehaviour {

	public WheelCollider[] m_WheelColliders = new WheelCollider[4];
	public GameObject[] m_WheelMeshes = new GameObject[4];
	public float m_MaximumSteerAngle;
	public float m_MaxHandbrakeTorque;
	public float m_BrakeTorque;
	public float m_ReverseTorque;
	public Vector3 m_CentreOfMassOffset;
	public float m_FullTorqueOverAllWheels;
	[Range(0, 1)] public float m_TractionControl; // 0 is no traction control, 1 is full interference

	private Quaternion[] m_WheelMeshLocalRotations;
	private float m_SteerAngle;
	private float m_CurrentTorque;
	private Rigidbody m_Rigidbody;

	public float AccelInput { get; private set; }
	public float BrakeInput { get; private set; }
	public float CurrentSpeed{ get { return m_Rigidbody.velocity.magnitude*2.23693629f; }}

	private void Start()
	{
		m_WheelMeshLocalRotations = new Quaternion[4];
		for (int i = 0; i < 4; i++)
		{
			m_WheelMeshLocalRotations[i] = m_WheelMeshes[i].transform.localRotation;
		}
		m_WheelColliders[0].attachedRigidbody.centerOfMass = m_CentreOfMassOffset;

		m_MaxHandbrakeTorque = float.MaxValue;

		m_Rigidbody = GetComponent<Rigidbody>();
		m_CurrentTorque = m_FullTorqueOverAllWheels - (m_TractionControl*m_FullTorqueOverAllWheels);
	}

	private void FixedUpdate()
	{
		// pass the input to the car!
		float h = Input.GetAxis("Horizontal");
		float v = Input.GetAxis("Vertical");
		//float handbrake = CrossPlatformInputManager.GetAxis("Jump");
		Move(h, v, v, 0f);
	}

	public void Move(float steering, float accel, float footbrake, float handbrake)
	{
		for (int i = 0; i < 4; i++)
		{
			Quaternion quat;
			Vector3 position;
			m_WheelColliders[i].GetWorldPose(out position, out quat);
			m_WheelMeshes[i].transform.position = position;
			m_WheelMeshes[i].transform.rotation = quat;
		}

		//clamp input values
		steering = Mathf.Clamp(steering, -1, 1);
		AccelInput = accel = Mathf.Clamp(accel, 0, 1);
		BrakeInput = footbrake = -1*Mathf.Clamp(footbrake, -1, 0);
		handbrake = Mathf.Clamp(handbrake, 0, 1);

		//Set the steer on the front wheels.
		//Assuming that wheels 0 and 1 are the front wheels.
		m_SteerAngle = steering*m_MaximumSteerAngle;
		m_WheelColliders[0].steerAngle = m_SteerAngle;
		m_WheelColliders[1].steerAngle = m_SteerAngle;

		//SteerHelper();
		ApplyDrive(accel, footbrake);
		//CapSpeed();

		//Set the handbrake.
		//Assuming that wheels 2 and 3 are the rear wheels.
		if (handbrake > 0f)
		{
			var hbTorque = handbrake*m_MaxHandbrakeTorque;
			m_WheelColliders[2].brakeTorque = hbTorque;
			m_WheelColliders[3].brakeTorque = hbTorque;
		}


		//CalculateRevs();
		//GearChanging();

		//AddDownForce();
		//CheckForWheelSpin();
		//TractionControl();
	}

	private void ApplyDrive(float accel, float footbrake)
	{

		float thrustTorque = accel * (m_CurrentTorque / 4f);
		for (int i = 0; i < 4; i++)
		{
			m_WheelColliders[i].motorTorque = thrustTorque;
		}

		for (int i = 0; i < 4; i++)
		{
			if (CurrentSpeed > 5 && Vector3.Angle(transform.forward, m_Rigidbody.velocity) < 50f)
			{
				m_WheelColliders[i].brakeTorque = m_BrakeTorque*footbrake;
			}
			else if (footbrake > 0)
			{
				m_WheelColliders[i].brakeTorque = 0f;
				m_WheelColliders[i].motorTorque = -m_ReverseTorque*footbrake;
			}
		}
	}

}
