using UnityEngine;
using System.Collections;

public class CompassOrientedCamera : MonoBehaviour {
    public float rotationSpeed;

    void OnEnable() {
        Screen.orientation = ScreenOrientation.Portrait;
        Input.compass.enabled = true;
        Input.location.Start();
        Input.gyro.enabled = true;
        Input.compensateSensors = false;
    }

	float yRotation; float xRotation;

	
	void Update () {

        Vector3 d = Vector3.ProjectOnPlane(Input.compass.rawVector, Input.gyro.gravity).normalized;
		float y = d.y;
		d.y = d.z;
		d.z = y;
        //d.z = -d.z;
        Quaternion targetRotation = Quaternion.LookRotation( -Input.gyro.gravity, d);
        //targetRotation *= Quaternion.Euler(0, 180, 0);
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

		//transform.rotation = Input.gyro.attitude;


		//yRotation += -Input.gyro.rotationRateUnbiased.y;
		//xRotation += -Input.gyro.rotationRateUnbiased.x;

		//transform.eulerAngles = new Vector3(xRotation, yRotation, 0); } 
	}
}
