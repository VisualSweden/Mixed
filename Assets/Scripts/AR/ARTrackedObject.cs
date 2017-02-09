using UnityEngine;
using System.Collections;
using System;
using Vuforia;

public class ARTrackedObject : MonoBehaviour, Vuforia.ITrackableEventHandler {

    private TrackableBehaviour mTrackableBehaviour;

    [HideInInspector]
    public Location location;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
            if (ScriptEventSystem.Instance.CurrentMode == ScriptEventSystem.Mode.AR && AREventSystem.Instance.CurrentMode == AREventSystem.ARMode.LookingForMarker) {
                AREventSystem.Instance.FoundTrackedLocation(location);
            }
        } else {
            AREventSystem.Instance.LostTrackedLocation(location);
        }
    }

    void Start() {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour) {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
}
