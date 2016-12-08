using UnityEngine;
using System.Collections;

public class ARCamera : MonoBehaviour {
	void Start () {
        ScriptEventSystem.Instance.OnSetARMode += OnSetARMode;
        gameObject.SetActive(false);
	}

    private void OnSetARMode(bool b) {
        gameObject.SetActive(b);
    }
}
