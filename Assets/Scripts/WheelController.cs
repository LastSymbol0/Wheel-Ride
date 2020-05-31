using UnityEngine;
using System.Collections;

public class WheelController : MonoBehaviour {
	
	public WheelCollider rcollider;
	public WheelCollider lcollider;
	public Rigidbody rb;
	public Transform tr;

	public Transform COM;

	public float moveCoef;

	public float maxSteer; //1
	public float maxAccel; //2
	public float maxBrake; //3
	
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
		rb.centerOfMass = COM.localPosition;
	}


	void FixedUpdate ()
	{
		float accel = 0;
		float steer = 0;
				
		accel = Input.GetAxis("Vertical");  //4
		steer = Input.GetAxis("Horizontal");     //4	

		//rb.AddForce(transform.forward * moveCoef * accel, ForceMode.Impulse);
		//transform.position = tr.position;
		CarMove(accel,steer); //5
		
	}
	
	private void CarMove(float accel, float steer)
	{
		rcollider.steerAngle = steer * maxSteer; //6
		lcollider.steerAngle = steer * maxSteer; //6

		if (accel == 0)
		{
			rcollider.brakeTorque = maxBrake;
			lcollider.brakeTorque = maxBrake;
		}
		else
		{
			rcollider.brakeTorque = 0; //8
			lcollider.brakeTorque = 0; //8
			rcollider.brakeTorque = 0; //8
			lcollider.motorTorque = accel * maxAccel; //8
		}
	}
}