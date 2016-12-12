using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapLocationDialog : MonoBehaviour {
    public Text Title;
    public Text Description;
    public Image Image;

    public Button ARMode;
    public Button Close;

    public GameObject MapControls;

	void Start () {
        ScriptEventSystem.Instance.OnLocationPressed += OnLocationPressed;
        gameObject.SetActive(false);
        ARMode.onClick.AddListener(delegate () { ScriptEventSystem.Instance.SetMode(ScriptEventSystem.Mode.AR); });
        Close.onClick.AddListener(delegate () { ShowDialog(false); });
        ScriptEventSystem.Instance.OnSetMode += OnSetMode;
	}

    private void OnSetMode(ScriptEventSystem.Mode m) {
        ShowDialog(false);
    }

    private void OnLocationPressed(Location l) {
        Title.text = l.Title;
        Description.text = l.Description;
        Image.sprite = l.Image;
        ShowDialog(true);
    }

    private void ShowDialog(bool show) {
        if (show) {
            gameObject.SetActive(true);
            MapControls.SetActive(false);
        } else {
            gameObject.SetActive(false);
            MapControls.SetActive(true);
        }
    }
}