using UnityEngine;
using System.Collections;

public class ArrowPointing : MonoBehaviour {

    public Camera PositionCamera;

    public GameObject pointTowards;

    public SpriteRenderer sprite;

	// Use this for initialization
	void Start () {
        sprite.transform.localPosition = new Vector3(0, Random.Range(-1f, 0f), 0);
        PositionCamera = FindObjectOfType<GyroscopeCamera>().GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = PositionCamera.transform.position + PositionCamera.transform.forward * 3;
        transform.LookAt(pointTowards.transform.position, (transform.position - PositionCamera.transform.position).normalized);

        Vector3 camera = transform.position - PositionCamera.transform.position;
        Vector3 d = transform.position - pointTowards.transform.position;

        transform.rotation = Quaternion.LookRotation(camera, d);

        float s = Vector3.Dot(PositionCamera.transform.forward, d.normalized);
        Color C = sprite.color;
        C.a = s;
        sprite.color = C;

	}
}
