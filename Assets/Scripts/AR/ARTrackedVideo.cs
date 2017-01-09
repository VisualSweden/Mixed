using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class ARTrackedVideo : MonoBehaviour, Vuforia.ITrackableEventHandler {
    private TrackableBehaviour mTrackableBehaviour;
    private MediaPlayerCtrl mediaPlayer;
    private bool ignoreEnd = false;

    public float resetTime;

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
        ScriptEventSystem.Instance.OnSetMode += OnSetMode;
    }

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus) {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
               newStatus == TrackableBehaviour.Status.TRACKED ||
               newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
            if (ScriptEventSystem.Instance.CurrentMode == ScriptEventSystem.Mode.AR)
                OnTrackingFound();
        } else {
            OnTrackingLost();
        }
    }

    private void OnSetMode(ScriptEventSystem.Mode m) {
        if (m != ScriptEventSystem.Mode.AR)
            OnTrackingLost();
    }

    private void OnTrackingFound() {
        CancelInvoke("OnTrackingTimedOut");
        mediaPlayer.gameObject.SetActive(true);
        mediaPlayer.Play();
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
        if (ScriptEventSystem.Instance.CurrentMode == ScriptEventSystem.Mode.AR) {
            mediaPlayer.SeekTo(0);
            mediaPlayer.Play();
        }
    }

    private void RestartVideo() {
        if (ScriptEventSystem.Instance.CurrentMode == ScriptEventSystem.Mode.AR && mediaPlayer.gameObject.activeInHierarchy) {
            ignoreEnd = true;
            mediaPlayer.Play();
            Invoke("PlayVideo", 0.01f);
        }
    }

    private void PlayVideo() {
        mediaPlayer.Play();
        Invoke("IgnoreEnd", 1);
    }

    private void IgnoreEnd() {
        ignoreEnd = false;
    }
}