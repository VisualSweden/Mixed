using UnityEngine;
using System.Collections;

public class GPSPositionedItem : MonoBehaviour {
    private Location myLocation;

    public float CameraDistance;

    public float speed;

	void Start () {
        myLocation = GetComponent<AddMapLocation>().Location;
        ScriptEventSystem.Instance.OnGoToLocation += Instance_OnLocationPressed;
        ScriptEventSystem.Instance.OnSetMode += Instance_OnSetMode;
        gameObject.SetActive(false);

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

    void OnEnable() {
        Screen.orientation = ScreenOrientation.Portrait;
        Input.compass.enabled = true;
        Input.location.Start();
        Input.gyro.enabled = true;
        Input.compensateSensors = false;
    }

    void Update() {
        Vector3 d = Vector3.ProjectOnPlane(Input.compass.rawVector, Input.gyro.gravity).normalized;
        d.z = -d.z;
        //d = Quaternion.Euler(0, CompassDirection, 0) * d;
        transform.position = Vector3.Slerp(transform.position, d * CameraDistance, Time.deltaTime * speed);
    }

    /*
    public float GetAngle(double userx, double usery, double posx, double posy) {


                // Calculate the tile position of locations.
                double userTileX, userTileY, markerTileX, markerTileY;
                OnlineMaps.instance.projection.CoordinatesToTile(userCoordinares.x, userCoordinares.y, zoom, out userTileX, out userTileY);
                OnlineMaps.instance.projection.CoordinatesToTile(markerCoordinates.x, markerCoordinates.y, zoom, out markerTileX, out markerTileY);

                // Calculate the angle between locations.
                double angle = OnlineMapsUtils.Angle2D(userTileX, userTileY, markerTileX, markerTileY);
                if (Math.Abs(userTileX - markerTileX) > maxX) angle = 360 - angle;

                Debug.Log("Angle: " + angle);

                // Calculate relative angle between locations.
                double relativeAngle = angle - compassTrueHeading;
                Debug.Log("Relative angle: " + relativeAngle);
        return relativeAngle;
    }*/
}
