using UnityEngine;
using System.Collections;
using System;

public class ScriptEventSystem : MonoBehaviour {
    public delegate void voidDeletage();
    public delegate void booldDeletage(bool b);
    public delegate void locatiodDeletage(Location l);

    public event booldDeletage OnSetARMode;
    public event booldDeletage OnSetMapMode;
    public event locatiodDeletage OnLocationPressed;

    public static ScriptEventSystem Instance;

    void Awake() {
        Instance = this;
    }

    public void SetARMode(bool arModeOn) {
        if (OnSetARMode != null)
            OnSetARMode(arModeOn);
    }

    public void SetMapMode(bool mapOn) {
        if (OnSetMapMode != null)
            OnSetMapMode(mapOn);
    }

    public void SelectedMapMarker(Location location) {
        if (OnLocationPressed != null)
            OnLocationPressed(location);
    }
}