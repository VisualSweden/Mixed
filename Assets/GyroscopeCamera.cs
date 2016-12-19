using UnityEngine;
using System.Collections;

public class GyroscopeCamera : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Input.gyro.enabled = true;
		Input.location.Start ();
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Input.gyro.attitude;
		transform.Rotate (9f, 0f, 180f, Space.Self);
		transform.Rotate (90f, 180f, 0f, Space.World);
	}
}
