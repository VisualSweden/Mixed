using UnityEngine;
using System.Collections;
using System;

public class ScriptEventSystem : MonoBehaviour {
    public delegate void locatiodDeletage(Location l);

    public delegate void modeDelegate(Mode m);

    public event locatiodDeletage OnLocationPressed;
    public event modeDelegate OnSetMode;

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

    public void SelectedMapMarker(Location location) {
        if (OnLocationPressed != null)
            OnLocationPressed(location);
    }
}