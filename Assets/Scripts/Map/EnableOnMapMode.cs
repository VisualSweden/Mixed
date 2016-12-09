using UnityEngine;
using System.Collections;

public class EnableOnMapMode : MonoBehaviour {
	void Start () {
        ScriptEventSystem eventSystem = FindObjectOfType<ScriptEventSystem>();
        eventSystem.OnSetMapMode += OnSetMapMode;
        gameObject.SetActive(false);
	}

    private void OnSetMapMode(bool b) {
        gameObject.SetActive(b);
    }
}