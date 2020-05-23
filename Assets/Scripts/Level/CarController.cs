using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
	private Rigidbody rb;

	public WheelCollider[] WColForward;
	public WheelCollider[] WColBack;

	public Transform wheelsT;

	public float wheelOffset = 1f;
	public float wheelRadius = 1.5f;

	public float maxSteer = 30;
	public float maxAccel = 25;
	public float maxBrake = 50;

	public Transform COM;

	public class WheelData
	{
		public Transform wheelTransform;
		public WheelCollider col;
		public Vector3 wheelStartPos;
		public float rotation = 0.0f; 
	}

	protected WheelData w;

	void Start()
	{
		rb = GetComponent<Rigidbody>();

		rb.centerOfMass = COM.localPosition;

		w = SetupWheels(wheelsT, WColForward[0]);
	}


	private WheelData SetupWheels(Transform wheel, WheelCollider col)
	{
		WheelData result = new WheelData();

		result.wheelTransform = wheel;
		result.col = col;
		result.wheelStartPos = wheel.transform.localPosition;

		return result;
	}

	void FixedUpdate()
	{
		if (!LevelController.IsGameStarted)
			return;

		float accel = 0;
		float steer = 0;

		accel = Input.GetAxis("Vertical");
		steer = Input.GetAxis("Horizontal");

		CarMove(accel, steer);
		UpdateWheel();

		if (Input.GetKeyDown("space"))
		{
			Jump();
		}
	}

	private void Jump()
	{
		// TODO: Add jump
	}

	private void UpdateWheel()
	{
		if (!LevelController.IsGameStarted)
			return;

		float delta = Time.fixedDeltaTime;

		WheelHit hit;

		Vector3 lp = w.wheelTransform.localPosition;
		if (w.col.GetGroundHit(out hit))
		{
			lp.y -= Vector3.Dot(w.wheelTransform.position - hit.point, transform.up) - wheelRadius;
		}
		else
		{

			lp.y = w.wheelStartPos.y - wheelOffset;
		}
		lp.y += 1.0f;
		w.wheelTransform.localPosition = lp;

		w.rotation = Mathf.Repeat(w.rotation + delta * w.col.rpm * 360.0f / 60.0f, 360.0f);
		w.wheelTransform.localRotation = Quaternion.Euler(w.rotation, w.col.steerAngle, 90.0f);

	}

	private void CarMove(float accel, float steer)
	{
		foreach (WheelCollider col in WColForward)
		{
			col.steerAngle = steer * maxSteer;
		}

		if (accel == 0)
		{
			foreach (WheelCollider col in WColBack)
			{
				col.brakeTorque = maxBrake;
			}
		}
		else
		{

			foreach (WheelCollider col in WColBack)
			{
				col.brakeTorque = 0;
				col.motorTorque = accel * maxAccel *
					(LevelController.Score > 1f ? LevelController.Score : 1f);
			}
		}
	}

}