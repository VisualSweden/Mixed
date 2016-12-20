using UnityEngine;
using System.Collections;
using System;

public class AddMapLocation : MonoBehaviour {
    public Location Location;

    void Start() {
		Debug.Log ("Registering " + Location.Title);
        ScriptEventSystem.Instance.OnSetMode += OnSetMode;
    }

    private void OnSetMode(ScriptEventSystem.Mode m) {
        if (m == ScriptEventSystem.Mode.Map) {
            MapManager.Instance.AddMarker(Location);
			Debug.Log ("Adding " + Location.Title);
            ScriptEventSystem.Instance.OnSetMode -= OnSetMode;
            //Destroy(this);
        }
    }
}