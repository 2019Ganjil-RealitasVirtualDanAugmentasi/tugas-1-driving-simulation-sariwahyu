using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {

	public void GetInput()
	{
		m_horizontalInput = Input.GetAxis("Horizontal");
		m_verticalInput = Input.GetAxis("Vertical");
	}

	private void Steer()
	{
		m_steeringAngle = maxSteerAngle * m_horizontalInput;
		depanKananW.steerAngle = m_steeringAngle;
		depanKirirW.steerAngle = m_steeringAngle;
	}

	private void Accelerate()
	{
		depanKananW.motorTorque = m_verticalInput * motorForce;
		depanKiriW.motorTorque = m_verticalInput * motorForce;
	}

	private void UpdateWheelPoses()
	{
		UpdateWheelPose(depanKananW, depanKananT);
		UpdateWheelPose(depanKiriW, depanKiriT);
		UpdateWheelPose(belakangKananW, belakangKananT);
		UpdateWheelPose(belakangKiriW, belakangKiriT);
	}

	private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
	{
		Vector3 _pos = _transform.position;
		Quaternion _quat = _transform.rotation;

		_collider.GetWorldPose(out _pos, out _quat);

		_transform.position = _pos;
		_transform.rotation = _quat;
	}

	private void FixedUpdate()
	{
		GetInput();
		Steer();
		Accelerate();
		UpdateWheelPoses();
	}

	private float m_horizontalInput;
	private float m_verticalInput;
	private float m_steeringAngle;

	public WheelCollider depanKananW, depanKiriW;
	public WheelCollider belakangKananW, belakangKananW;
	public Transform depanKananT, depanKiriT;
	public Transform belakangKananT, belakangKiriT;
	public float maxSteerAngle = 30;
	public float motorForce = 50;
}
