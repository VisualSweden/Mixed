using UnityEngine;
using System.Collections;

public class LocationGUI : MonoBehaviour {

    public AddMapLocation location;

    private bool isOnLocation;
    private bool isObjectVisible;
    private bool arMode;

    void Start() {
        ScriptEventSystem.Instance.OnGoToLocation += Instance_OnGoToLocation;
        ScriptEventSystem.Instance.OnSetMode += Instance_OnSetMode;
        ScriptEventSystem.Instance.OnEnterNewsARMode += Instance_OnEnterNewsARMode;

        ScriptEventSystem.Instance.OnSoundObjectVisible += () => { isObjectVisible = true; UpdateVisible(); };
        ScriptEventSystem.Instance.OnSoundObjectHidden += () => { isObjectVisible = false; UpdateVisible(); };

        gameObject.SetActive(false);
    }

    private void Instance_OnEnterNewsARMode(Vector2 pos) {
        isOnLocation = false;
        UpdateVisible();
    }

    private void Instance_OnSetMode(ScriptEventSystem.Mode m) {
        arMode = m == ScriptEventSystem.Mode.AR;
        UpdateVisible();
    }

    private void UpdateVisible() {
        gameObject.SetActive(isOnLocation && !isObjectVisible && arMode);
    }

    private void Instance_OnGoToLocation(Location l) {
        isOnLocation = l == location.Location;
        UpdateVisible();
    }
}
