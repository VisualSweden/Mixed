using UnityEngine;
using System.Collections;

public class TriggerAudioTrack : MonoBehaviour {
	private Location myLocation;
	private AudioSource audio;
	private bool triggered;

	public GameObject enableOnTrigger;

	void Start () {
		audio = GetComponent<AudioSource> ();
		myLocation = GetComponent<AddMapLocation> ().Location;
	}
	
	void Update () {
		if (!triggered) {
			Vector2 player = MapManager.Instance.location.position;
			Vector2 location = new Vector2 ((float)myLocation.Longitude, (float)myLocation.Latitude);
			float distance = OnlineMapsUtils.DistanceBetweenPoints (player, location).magnitude * 1000;
			if (distance < myLocation.TriggerDistance) {
				Trigger ();
			}
		}
	}

	public void Trigger() {
		if (enableOnTrigger)
			enableOnTrigger.SetActive (true);
		triggered = true;
		audio.Play ();
		Handheld.Vibrate ();
	}
}
