using UnityEngine;
using System.Collections;
using System;

public class AddMapLocation : MonoBehaviour {
    public Location Location;

    void Start() {
        MapManager.Instance.AddMarker(Location);
    }
}

