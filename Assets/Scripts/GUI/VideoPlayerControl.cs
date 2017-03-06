using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class VideoPlayerControl : MonoBehaviour {

    void Start() {
        //ScriptEventSystem.Instance.OnGoToLocation += GoToLocation;
        AREventSystem.Instance.OnSetMode += SetARMode;
		gameObject.SetActive (false);
    }

    private void SetARMode(AREventSystem.ARMode m) {
        gameObject.SetActive(m == AREventSystem.ARMode.VideoPlayer);
    }
}