using UnityEngine;
using System.Collections;

public class FaceCamera : MonoBehaviour {
	private GyroscopeCamera camera;


	void Update () {
		if (!camera) {
			camera = FindObjectOfType<GyroscopeCamera> ();
		}
		transform.LookAt (camera.transform.position);
		transform.Rotate (0, 180, 0,
			Space.Self);
	}
}
