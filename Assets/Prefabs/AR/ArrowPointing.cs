using UnityEngine;
using System.Collections;

public class ArrowPointing : MonoBehaviour {

    public Camera PositionCamera;

    public GameObject pointTowards;

    public SpriteRenderer sprite;

    public AnimationCurve AlphaCurve;

    // Use this for initialization
    void Start () {
        //sprite.transform.localPosition = new Vector3(0, Random.Range(-1f, 0f), 0);
        PositionCamera = FindObjectOfType<GyroscopeCamera>().GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = PositionCamera.transform.position + PositionCamera.transform.forward * 6;
        transform.LookAt(pointTowards.transform.position, (transform.position - PositionCamera.transform.position).normalized);

        Vector3 camera = transform.position - PositionCamera.transform.position;
        Vector3 d = transform.position - pointTowards.transform.position;

        transform.rotation = Quaternion.LookRotation(camera, d);

        float s = (1 + Vector3.Dot(PositionCamera.transform.forward, (PositionCamera.transform.position - pointTowards.transform.position).normalized))/2.0f;
        Color C = sprite.color;
        C.a = AlphaCurve.Evaluate(s);
        sprite.color = C;

	}
}
