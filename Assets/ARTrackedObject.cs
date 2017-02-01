using UnityEngine;
using System.Collections;
using System;
using Vuforia;

public class ARTrackedObject : MonoBehaviour, Vuforia.ITrackableEventHandler {

    private TrackableBehaviour mTrackableBehaviour;

    private Location location;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED ||
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
            AREventSystem.Instance.FoundTrackedLocation(location);
        } else {
            AREventSystem.Instance.LostTrackedLocation(location);
        }
    }

    void Start() {
        location = GetComponent<AddMapLocation>().Location;

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour) {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }
    }
}
