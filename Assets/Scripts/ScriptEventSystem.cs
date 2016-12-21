using UnityEngine;
using System.Collections;
using System;

public class ScriptEventSystem : MonoBehaviour {
    public delegate void locatiodDeletage(Location l);
	public delegate void boolDelegate(bool b);
    public delegate void modeDelegate(Mode m);
	public delegate void voidDelegate ();

    public event locatiodDeletage OnLocationPressed;
    public event locatiodDeletage OnGoToLocation;
    public event modeDelegate OnSetMode;
	public event boolDelegate OnSetSoundOn;
	public event voidDelegate OnSoundObjectVisible;
	public event voidDelegate OnSoundObjectHidden;
    public event voidDelegate OnVideoFinished;
    public event voidDelegate OnVideoRestart;

    public static ScriptEventSystem Instance;

    public Mode CurrentMode;

    public enum Mode {
        Menu,
        Map,
        AR
    }

    void Awake() {
        Instance = this;
    }

    public void SetMode(Mode m) {
        if (OnSetMode != null)
            OnSetMode(m);
        CurrentMode = m;
    }

    public void GoToLocation(Location l) {
        if (OnGoToLocation != null)
            OnGoToLocation(l);
    }

    public void SelectedMapMarker(Location location) {
        if (OnLocationPressed != null)
            OnLocationPressed(location);
    }

	public void SetSoundOn(bool b) {
		if (OnSetSoundOn != null)
			OnSetSoundOn(b);
	}

	public void SoundObjectVisible() {
		if (OnSoundObjectVisible != null)
			OnSoundObjectVisible();
	}

	public void SoundObjectHidden() {
		if (OnSoundObjectHidden != null)
			OnSoundObjectHidden();
	}

    public void VideoFinished() {
        if (OnVideoFinished != null)
            OnVideoFinished();
    }

    public void VideoRestart() {
        if (OnVideoRestart != null)
            OnVideoRestart();
    }
}