using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeIcon : MonoBehaviour {
	private Toggle toggle;

	void Start () {
		ScriptEventSystem.Instance.OnSoundObjectVisible += () => {gameObject.SetActive(true);};
		ScriptEventSystem.Instance.OnSoundObjectHidden += () => {gameObject.SetActive(false);};

		toggle = GetComponent<Toggle> ();
		toggle.onValueChanged.AddListener (delegate (bool b){
			ScriptEventSystem.Instance.SetSoundOn (b);
		});
		gameObject.SetActive (false);
	}
}
