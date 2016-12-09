using UnityEngine;
using System.Collections;

public class ExploreToggle : MonoBehaviour {
    public void ToggleChanged(bool value) {
        ScriptEventSystem.Instance.SetMapMode(value);
    }
}
