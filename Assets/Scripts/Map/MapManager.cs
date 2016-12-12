using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {
    public OnlineMaps map;
    public OnlineMapsLocationService location;

    public static MapManager Instance;

    public bool trackPlayer;

    public float maxLat;
    public float minLat;
    public float maxLng;
    public float minLng;

    public int maxZoom;
    public int minZoom;

    void Awake() {
        Instance = this;
        location.OnLocationChanged += LocationChanged;
        map.positionRange = new OnlineMapsPositionRange(minLat, minLng, maxLat, maxLng);
        map.zoomRange = new OnlineMapsRange(minZoom, maxZoom);
    }

    public void AddMarker(Location Location) {
        OnlineMaps map = FindObjectOfType<OnlineMaps>();
        OnlineMapsMarker marker = new OnlineMapsMarker();
        marker.SetPosition(Location.Longitude, Location.Latitude);
        marker.texture = Location.Thumbnail;
        marker.customData = Location.ID; // Points towards our game object, so we can enable it
        marker.OnClick += delegate (OnlineMapsMarkerBase obj) { ScriptEventSystem.Instance.SelectedMapMarker(Location); };
        marker.Init();
        map.AddMarker(marker);
    }

    public void LocationChanged(Vector2 location) {
        if (trackPlayer)
            map.SetPosition(location.x, location.y);
    }

    public void CenterOnPlayer(bool b) {
        trackPlayer = b;
        if (b)
            location.UpdatePosition();
    }
}