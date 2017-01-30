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
        float angle = (float)Angle(new Vector2((float)Input.location.lastData.latitude, (float)Input.location.lastData.longitude), new Vector2((float)Latitude, (float)Longitude));
		Vector3 pos = Quaternion.Euler (0, (float)angle, 0) * Vector3.forward * CameraDistance;
		transform.position = pos;
	}

    private double Angle(Vector2 userCoordinares, Vector2 markerCoordinates) {
        int zoom = 15;
        int maxX = 1 << (zoom - 1);

        double userTileX, userTileY, markerTileX, markerTileY;

        OnlineMapsProjection projection = MapManager.Instance.map.projection;

        projection.CoordinatesToTile(userCoordinares.x, userCoordinares.y, zoom, out userTileX, out userTileY);
        projection.CoordinatesToTile(markerCoordinates.x, markerCoordinates.y, zoom, out markerTileX, out markerTileY);

        // Calculate the angle between locations.
        double angle = OnlineMapsUtils.Angle2D(userTileX, userTileY, markerTileX, markerTileY);

        return angle;
    }

}