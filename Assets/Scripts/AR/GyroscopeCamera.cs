using UnityEngine;
using System.Collections;

public class GyroscopeCamera : MonoBehaviour {
	
	void OnEnable () {
		Input.gyro.enabled = true;
        Input.compass.enabled = true;
		Input.location.Start ();
	}

	void Update () {
		transform.rotation = Input.gyro.attitude;
		transform.Rotate (9f, 0f, 180f, Space.Self);
		transform.Rotate (90f, 180f, 0f, Space.World);
	}
}
