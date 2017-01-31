using UnityEngine;
using System.Collections;

public class IntroGUI : MonoBehaviour {
    public void IntroFinished() {
        ScriptEventSystem.Instance.SetMode(ScriptEventSystem.Mode.Map);

    }
}
