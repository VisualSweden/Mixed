using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LocationManager : MonoBehaviour {
    public Location[] AddLocations;
    public static LocationManager Instance;

    private Dictionary<int, Location> locations;
    private Dictionary<int, GameObject> trackedObjects;

	void Awake () {
        trackedObjects = new Dictionary<int, GameObject>();
        Instance = this;
        locations = new Dictionary<int, Location>();
        foreach (var l in AddLocations) {
            AddLocation(l);
            SpawnTrackedObject(l);
        }
        //ScriptEventSystem.Instance.OnGoToLocation += SpawnTrackedObject;
	}

    private bool IsLocationLoaded(Location l) {
        return trackedObjects.ContainsKey(l.ID);
    }

    private void SpawnTrackedObject(Location l) {
        if (l.TrackedObject != null && !IsLocationLoaded(l)) {
            GameObject trackedObject = Instantiate(l.TrackedObject);
            ILocationObject tracked = trackedObject.GetComponent<ILocationObject>();
            if (tracked != null)
                tracked.Location = l;
            trackedObjects.Add(l.ID, trackedObject);
        }
    }

    public void AddLocation(Location l) {
        locations.Add(l.ID, l);
        MapManager.Instance.AddMarker(l);
    }

    public Location GetLocation(int ID) {
        return locations[ID];
    }
}
