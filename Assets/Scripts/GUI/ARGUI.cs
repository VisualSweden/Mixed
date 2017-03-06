using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ARGUI : MonoBehaviour {

    public Button findButton;

	void Start () {
        findButton.onClick.AddListener(delegate () { ScriptEventSystem.Instance.SetMode(ScriptEventSystem.Mode.Map); });
	}
}
