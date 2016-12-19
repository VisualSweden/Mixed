using UnityEngine;
using System.Collections;

public class GravityPointer : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		Input.location.Start ();
	}
	
	// Update is called once per frame
	void Update () {

		//Vector3 v = Input.gyro.gravity;
		//float z = v.z;
		//v.z = v.y;
		//v.y = z;

		//Vector3 magnet = Input.compass.rawVector;

		//Vector3 d = Vector3.ProjectOnPlane(magnet, Input.gyro.gravity).normalized;
		//float y = d.y;
		//d.y = d.z;
		//d.z = y;
		//d.z = -d.z;
		//Quaternion targetRotation = Quaternion.LookRotation(d, -Input.gyro.gravity);
		//targetRotation *= Quaternion.Euler(0, 180, 0);
		//transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);



		//transform.rotation = Quaternion.LookRotation( d, -v );


		////////////////////////////////////////////////////////////


		Vector3 magnetF = Quaternion.LookRotation( Input.compass.rawVector) * Vector3.forward;

		Vector3 r = Input.gyro.gravity;
		r = Quaternion.LookRotation(r).eulerAngles;

		//transform.rotation = Quaternion.Euler (-r.x, r.y, r.z);

		Vector3 up = Quaternion.Euler (-r.x, r.y, r.z) * Vector3.forward;

		Vector3 d = Vector3.ProjectOnPlane(magnetF, up).normalized;

		transform.rotation = Quaternion.LookRotation (up, d);
		
		//transform.rotation = Quaternion.Euler( -r.x, r.y, r.z);

		//transform.rotation = Quaternion.Euler(-180,0,0) * Input.gyro.attitude; //*Quaternion.Euler(90,0,0);
	
	}
}
