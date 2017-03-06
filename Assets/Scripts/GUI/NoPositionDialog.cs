using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class NoPositionDialog : MonoBehaviour {
    public Button OkButton;

    private bool hasClosed;

	void Start () {
        OkButton.onClick.AddListener(delegate { Close(); });
        ScriptEventSystem.Instance.OnSetMode += delegate (ScriptEventSystem.Mode m) { DialogCheck(); };
        MapManager.Instance.location.OnLocationChanged += delegate(Vector2 v) { DialogCheck(); };
        gameObject.SetActive(false);
        Invoke("DialogCheck", 3);
    }

    private void DialogCheck() { 
        if (!hasClosed && ScriptEventSystem.Instance.CurrentMode == ScriptEventSystem.Mode.Map && !MapManager.Instance.HasPosition) {
            Show();
        }
    }

    public void Show() {
        gameObject.SetActive(true);
    }

    public void Close() {
        gameObject.SetActive(false);
        //hasClosed = true;
    }
}