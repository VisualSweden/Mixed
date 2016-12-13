using UnityEngine;
using System.Collections;

public class ExploreToggle : MonoBehaviour {
    public void ToggleChanged(bool value) {
        if (value) {
            ScriptEventSystem.Instance.SetMode(ScriptEventSystem.Mode.Map);
        } else {
            ScriptEventSystem.Instance.SetMode(ScriptEventSystem.Mode.Menu);
        }
    }
}
