using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {
    public OnlineMaps map;
    public OnlineMapsLocationService location;

    public static MapManager Instance;

    public double maxLat;
    public double minLat;
    public double maxLng;
    public double minLng;

    void Awake() {
        Instance = this;
  //      map.positionRange.type == OnlineMapsPositionRangeType.maxLat = maxLat;
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

    public void CenterOnPlayer() {
        location.UpdatePosition();
    }
}