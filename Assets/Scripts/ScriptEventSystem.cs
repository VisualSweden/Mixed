using UnityEngine;
using System.Collections;
using System;

public class ScriptEventSystem : MonoBehaviour {
    public delegate void locatiodDeletage(Location l);
    public delegate void newsarticleDelegate(Newsarticle article);
	public delegate void boolDelegate(bool b);
    public delegate void modeDelegate(Mode m);
	public delegate void voidDelegate ();
	public delegate void vector2Delegate (Vector2 pos);

    public event locatiodDeletage OnLocationPressed;
    public event newsarticleDelegate OnArticlePressed;
    public event locatiodDeletage OnGoToLocation;
    public event modeDelegate OnSetMode;
	public event boolDelegate OnSetSoundOn;
	public event voidDelegate OnSoundObjectVisible;
	public event voidDelegate OnSoundObjectHidden;
    public event voidDelegate OnVideoFinished;
    public event voidDelegate OnVideoRestart;
    public event voidDelegate OnPlayerMovesMap;
    public event vector2Delegate OnEnterNewsARMode;

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

    public void PlayerMovesMap() {
        if (OnPlayerMovesMap != null)
            OnPlayerMovesMap();
    }

    public void GoToLocation(Location l) {
        if (OnGoToLocation != null)
            OnGoToLocation(l);
    }

    public void SelectedMapMarker(Location location) {
        if (OnLocationPressed != null)
            OnLocationPressed(location);
    }

    public void SelectedNewsarticleMarker(Newsarticle article) {
        if (OnArticlePressed != null)
            OnArticlePressed(article);
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

    public void EnterNewsARMode() {
        if (OnEnterNewsARMode != null)
            OnEnterNewsARMode(Vector2.zero);
    }

    // Enter map mode when toggle focus.
    void OnApplicationPause(bool pauseStatus) {
        if (pauseStatus) {
            if (CurrentMode == Mode.AR)
                SetMode(Mode.Map);
        }
    }
}