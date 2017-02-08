﻿using UnityEngine;
using System.Collections;
using Vuforia;
using System;

public class ARTrackedVideo : MonoBehaviour, Vuforia.ITrackableEventHandler {
    private TrackableBehaviour mTrackableBehaviour;
    private MediaPlayerCtrl mediaPlayer;
    private bool ignoreEnd = false;
    private Camera mainCamera;

    private bool isTracked;
    private bool isVideoVisible;

    public float resetTime;

    void Awake() {
        mainCamera = FindObjectOfType<VuforiaBehaviour>().GetComponentInChildren<Camera>();
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
            if (ScriptEventSystem.Instance.CurrentMode == ScriptEventSystem.Mode.AR && AREventSystem.Instance.CurrentMode == AREventSystem.ARMode.LookingForMarker) {
                //OnTrackingFound();
                isTracked = true;
                AREventSystem.Instance.FoundTrackedMovie(mediaPlayer);
            }
        } else {
            OnTrackingLost();
            isTracked = false;
            isVideoVisible = false;
            AREventSystem.Instance.LostTrackedMovie(mediaPlayer);
        }
    }

    void Update() {
        if (isTracked) {
            Vector3 cam = mainCamera.transform.forward;
            Vector3 dir = mainCamera.transform.position - mediaPlayer.transform.position;
            if (isVideoVisible) {
                if (Vector3.Dot(cam, dir) > 0) {
                    OnTrackingLost();
                    isVideoVisible = false;
                }

            } else {
                if (Vector3.Dot(cam, dir) < 0) {
                    OnTrackingFound();
                    isVideoVisible = true;
                }

            }
        }
    }

    private void OnSetMode(ScriptEventSystem.Mode m) {
        if (m != ScriptEventSystem.Mode.AR) {
            OnTrackingLost();
            mediaPlayer.SeekTo(0);
        }
    }

    private void OnTrackingFound() {
        isTracked = true;
        CancelInvoke("OnTrackingTimedOut");
        mediaPlayer.gameObject.SetActive(true);
        mediaPlayer.Play();
    }

    private void OnTrackingLost() {
        isTracked = false;
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
            //mediaPlayer.Play();
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