using UnityEngine;
using System.Collections;
using System;

public class AddMapLocation : MonoBehaviour {
    public Location Location;

    void Start() {
        ScriptEventSystem.Instance.OnSetMode += OnSetMode;
    }

    private void OnSetMode(ScriptEventSystem.Mode m) {
        if (m == ScriptEventSystem.Mode.Map) {
            MapManager.Instance.AddMarker(Location);
            ScriptEventSystem.Instance.OnSetMode -= OnSetMode;
            Destroy(this);
        }
    }
}

