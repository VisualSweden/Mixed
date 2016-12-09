using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapLocationDialog : MonoBehaviour {
    public Text Title;
    public Text Description;
    public Image Image;

    public Button ARMode;
    public Button Close;

	void Start () {
        ScriptEventSystem.Instance.OnLocationPressed += OnLocationPressed;
        gameObject.SetActive(false);
        ARMode.onClick.AddListener(delegate () { ScriptEventSystem.Instance.SetMode(ScriptEventSystem.Mode.AR); });
        Close.onClick.AddListener(delegate () { gameObject.SetActive(false); });
	}

    private void OnLocationPressed(Location l) {
        Title.text = l.Title;
        Description.text = l.Description;
        Image.sprite = l.Image;
        gameObject.SetActive(true);
    }
}