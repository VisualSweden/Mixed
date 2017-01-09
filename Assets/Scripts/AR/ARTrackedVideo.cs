using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class ARTrackedVideo : MonoBehaviour, Vuforia.ITrackableEventHandler {
    private TrackableBehaviour mTrackableBehaviour;
    private MediaPlayerCtrl mediaPlayer;

    public float resetTime;

    private bool ignoreEnd = false;

    void Awake() {
        mediaPlayer = GetComponentInChildren<MediaPlayerCtrl>();
        mediaPlayer.OnEnd += delegate () {
            if(mediaPlayer.GetSeekPosition() > 0 && !ignoreEnd)
                ScriptEventSystem.Instance.VideoFinished();
        };

        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour) {
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
        }

        ScriptEventSystem.Instance.OnVideoRestart += RestartVideo;
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
        //mediaPlayer.Stop();
        //mediaPlayer.gameObject.SetActive(false);
        mediaPlayer.SeekTo(0);
        mediaPlayer.Play();
    }

    private void RestartVideo() {
        if (mediaPlayer.gameObject.activeInHierarchy) {
        ignoreEnd = true;
        //mediaPlayer.gameObject.SetActive(false);
            //mediaPlayer.SeekTo(0);
            mediaPlayer.Play();
            Invoke("PlayVideo", 0.01f);
        }
    }

    private void PlayVideo() {
            mediaPlayer.Play();
            Invoke("En", 1);
    }

    private void En() {
        //mediaPlayer.gameObject.SetActive(true);
        ignoreEnd = false;

    }
}
