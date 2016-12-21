using UnityEngine;
using System.Collections;

public class GPSPositionedItem : MonoBehaviour {
    private Location myLocation;

    public float CameraDistance;

	public double Longitude;
	public double Latitude;

	IEnumerator Start () {
        myLocation = GetComponent<AddMapLocation>().Location;
        ScriptEventSystem.Instance.OnGoToLocation += Instance_OnLocationPressed;
        ScriptEventSystem.Instance.OnSetMode += Instance_OnSetMode;
		yield return new WaitForFixedUpdate ();
		gameObject.SetActive(false);
	}

	void OnEnable() {
		Input.location.Start ();
	}

    private void Instance_OnSetMode(ScriptEventSystem.Mode m) {
        if (m != ScriptEventSystem.Mode.AR)
            gameObject.SetActive(false);
    }

    private void Instance_OnLocationPressed(Location l) {
        if (l == myLocation) {
            gameObject.SetActive(true);
        }
    }

	void Update() {
		float userTileX, userTileY, markerTileX, markerTileY;
		double angle = OnlineMapsUtils.Angle2D(Input.location.lastData.latitude, Input.location.lastData.longitude, Latitude, Longitude);

		Vector3 pos = Quaternion.Euler (0, (float)angle, 0) * Vector3.forward *CameraDistance;
		transform.position = pos;
	}

}