using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VolumeIcon : MonoBehaviour {

	void Start () {
		ScriptEventSystem.Instance.OnSoundObjectVisible += () => {gameObject.SetActive(true);};
		ScriptEventSystem.Instance.OnSoundObjectHidden += () => {gameObject.SetActive(false);};
		gameObject.SetActive (false);
	}
}
