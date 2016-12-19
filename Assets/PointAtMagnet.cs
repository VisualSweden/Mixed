using UnityEngine;
using System.Collections;

public class PointAtMagnet : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.localRotation = Quaternion.LookRotation( Input.compass.rawVector);
	}
}
