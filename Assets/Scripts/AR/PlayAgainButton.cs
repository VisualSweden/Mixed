using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayAgainButton : MonoBehaviour {
    public Button button;

	void Start () {
		ScriptEventSystem.Instance.OnSoundObjectHidden += () => {gameObject.SetActive(false);};
		ScriptEventSystem.Instance.OnVideoFinished += () => {
            gameObject.SetActive(true);
        };

        button = GetComponent<Button>();
		button.onClick.AddListener (delegate (){
            ScriptEventSystem.Instance.VideoRestart();
            gameObject.SetActive(false);
		});
		gameObject.SetActive (false);
	}
}
