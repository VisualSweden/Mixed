using UnityEngine;
using System.Collections;

public class EnableOnMode : MonoBehaviour {
    public ScriptEventSystem.Mode VisibleInMode;

	void Start () {
        ScriptEventSystem.Instance.OnSetMode += OnSetMode;
        gameObject.SetActive(false);
	}

    private void OnSetMode(ScriptEventSystem.Mode m) {
        gameObject.SetActive(m == VisibleInMode);
    }
}
