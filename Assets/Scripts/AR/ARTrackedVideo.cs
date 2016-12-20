using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class ARTrackedVideo : MonoBehaviour, Vuforia.ITrackableEventHandler {
    private TrackableBehaviour mTrackableBehaviour;
    private MediaPlayerCtrl mediaPlayer;


    public float resetTime;

    void Awake() {
        mediaPlayer = GetComponentInChildren<MediaPlayerCtrl>();
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour) {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
               newStatus == TrackableBehaviour.Status.TRACKED ||
               newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
            OnTrackingFound();
        } else {
            OnTrackingLost();
        }
    }

    private void OnTrackingFound() {
        CancelInvoke("OnTrackingTimedOut");
        mediaPlayer.gameObject.SetActive(true);
    }

    private void OnTrackingLost() {
        mediaPlayer.gameObject.SetActive(false);
        CancelInvoke("OnTrackingTimedOut");
        Invoke("OnTrackingTimedOut", resetTime);
    }

    void OnDisable() {
        CancelInvoke("OnTrackingTimedOut");
        Invoke("OnTrackingTimedOut", resetTime);
    }

    private void OnTrackingTimedOut() {
        mediaPlayer.SeekTo(0);
    }
}
