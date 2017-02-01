using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayAgainButton : MonoBehaviour {
    private Button button;

    void Start() {
        AREventSystem.Instance.OnSetMode += (AREventSystem.ARMode m) => { if (m != AREventSystem.ARMode.NotInAR) gameObject.SetActive(false); };

        AREventSystem.Instance.OnLostTrackedMovie += (MediaPlayerCtrl m) => { gameObject.SetActive(false); };
        ScriptEventSystem.Instance.OnVideoFinished += () => {
            gameObject.SetActive(true);
        };

        button = GetComponent<Button>();
        button.onClick.AddListener(delegate () {
            ScriptEventSystem.Instance.VideoRestart();
            gameObject.SetActive(false);
        });
        gameObject.SetActive(false);
    }
}