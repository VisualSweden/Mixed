using UnityEngine;
using System.Collections;
using Vuforia;

public class RemoveTrackingWhenDestroyed : MonoBehaviour {
    void OnDestroy() {
        return;
        TrackableBehaviour mTrackableBehaviour;
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        TrackerManager.Instance.GetStateManager().DestroyTrackableBehavioursForTrackable(mTrackableBehaviour.Trackable);
    }
}
