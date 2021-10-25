using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCarController : MonoBehaviour {
	private float m_horizontalInput;
	private float m_verticalInput;
	private float m_steeringAngle;

	public WheelCollider frontDriverW, frontPassengerW;
	public WheelCollider rearDriverW, rearPassengerW;
	public Transform frontDriverT, frontPassengerT;
	public Transform rearDriverT, rearPassengerT;
	public float maxSteerAngle = 30;
	public float motorForce = 50;

	public Transform centerOfMass;
	//public Rigidbody rigidbody;
    private void Start()
    {
		//rigidbody.GetComponent<Rigidbody>();
    }
    public void GetInput()
	{
		m_horizontalInput = Input.GetAxis("Horizontal");
		m_verticalInput = Input.GetAxis("Vertical");
	}

	private void Steer()
	{
		m_steeringAngle = maxSteerAngle * m_horizontalInput;
		frontDriverW.steerAngle = m_steeringAngle;
		frontPassengerW.steerAngle = m_steeringAngle;

		//rearDriverW.steerAngle = m_steeringAngle;
		//rearPassengerW.steerAngle = m_steeringAngle;
	}

	private void Accelerate()
	{
		frontDriverW.motorTorque = m_verticalInput * motorForce;
		frontPassengerW.motorTorque = m_verticalInput * motorForce;

		rearDriverW.motorTorque = m_verticalInput * motorForce;
		rearPassengerW.motorTorque = m_verticalInput * motorForce;
	}

	private void UpdateWheelPoses()
	{
		UpdateWheelPose(frontDriverW, frontDriverT);
		UpdateWheelPose(frontPassengerW, frontPassengerT);
		UpdateWheelPose(rearDriverW, rearDriverT);
		UpdateWheelPose(rearPassengerW, rearPassengerT);
	}

	
	private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
	{
		Vector3 _pos = _transform.position;
		Quaternion _quat = _transform.rotation;

		_collider.GetWorldPose(out _pos, out _quat);

		_transform.position = _pos;
		_transform.rotation = _quat;

		//transform.position = _pos;
		//transform.rotation = _quat;
	}

	

	private void FixedUpdate()
	{
		GetInput();
		Steer();
		Accelerate();
		UpdateWheelPoses();

		//rigidbody.centerOfMass = transform.InverseTransformPoint(centerOfMass.position);

	}

	
}
