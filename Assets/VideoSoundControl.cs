using UnityEngine;
using System.Collections;

public class VideoSoundControl : MonoBehaviour {

	private MediaPlayerCtrl mediaPlayer;

	void Start () {
		mediaPlayer = GetComponent<MediaPlayerCtrl> ();
		ScriptEventSystem.Instance.OnSetSoundOn += (bool b) => {mediaPlayer.SetVolume( b?1:0 );};
	}
	
	void OnEnable() {
		ScriptEventSystem.Instance.SoundObjectVisible ();
	}

	void OnDisable() {
		ScriptEventSystem.Instance.SoundObjectHidden ();
	}
}
