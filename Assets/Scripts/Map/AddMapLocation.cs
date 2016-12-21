using UnityEngine;
using System.Collections;
using System;

public class AddMapLocation : MonoBehaviour {
    public Location Location;

    void Start() {
		if (ScriptEventSystem.Instance.CurrentMode == ScriptEventSystem.Mode.Map) {
			AddLocation ();
		} else {
			ScriptEventSystem.Instance.OnSetMode += OnSetMode;
		}
    }

    private void OnSetMode(ScriptEventSystem.Mode m) {
        if (m == ScriptEventSystem.Mode.Map) {
			Debug.Log ("Adding " + Location.Title);
            ScriptEventSystem.Instance.OnSetMode -= OnSetMode;
			AddLocation ();
        }
    }
	private void AddLocation() {
		MapManager.Instance.AddMarker(Location);
		Destroy(this);
	}
}