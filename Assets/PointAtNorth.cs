using UnityEngine;
using System.Collections;

public class PointAtNorth : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Input.compass.enabled = true;
		Input.location.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 magnetF = Input.compass.rawVector;

		Vector3 r = Input.gyro.gravity;
		r = Quaternion.LookRotation(r).eulerAngles;

		//transform.rotation = Quaternion.Euler (-r.x, r.y, r.z);

		Vector3 up = Quaternion.Euler (-r.x, r.y, r.z) * Vector3.forward;

		//up = new Vector3 (up.z, up.y, up.x); 

		//Vector3 d = Vector3.ProjectOnPlane(magnetF, up).normalized;

		Vector3 d = magnetF - Vector3.Dot (magnetF, -up) * -up;


		transform.localRotation = Quaternion.LookRotation (d, up);


	}
}
