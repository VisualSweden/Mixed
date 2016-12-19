using UnityEngine;
using System.Collections;

public class PointAtGravity : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		Input.location.Start ();
	}
	
	// Update is called once per frame
	void Update () {

		//transform.Rotate (Input.gyro.rotationRate);

		Vector3 r = Input.gyro.gravity;
		r = Quaternion.LookRotation(r).eulerAngles;
		transform.localRotation = Quaternion.Euler( -r.x, r.y, r.z);
	}
}
