using UnityEngine;
using System.Collections;

public class LocationGUI : MonoBehaviour {

    public AddMapLocation location;

	void Start () {
        ScriptEventSystem.Instance.OnGoToLocation += Instance_OnGoToLocation;
        ScriptEventSystem.Instance.OnSetMode += Instance_OnSetMode;
        gameObject.SetActive(false);
    }

    private void Instance_OnSetMode(ScriptEventSystem.Mode m) {
        if (m != ScriptEventSystem.Mode.AR) {
            gameObject.SetActive(false);
        }
    }

    private void Instance_OnGoToLocation(Location l) {
        if (l == location.Location)
            gameObject.SetActive(true);
        else
            gameObject.SetActive(false);
    }
}
