using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {
    public OnlineMaps map;

    public static MapManager Instance;

    void Awake() {
        Instance = this;
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
}
