using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapLocationDialog : MonoBehaviour {
    public Text Title;
    public Text Description;
    public Image Image;

    public Text FarAwayText;

    public Button ARMode;
    public Button Close;

    public GameObject MapControls;

    private Location selectedLocation;

	void Start () {
        ScriptEventSystem.Instance.OnLocationPressed += OnLocationPressed;
        gameObject.SetActive(false);
        ARMode.onClick.AddListener(delegate () { ScriptEventSystem.Instance.SetMode(ScriptEventSystem.Mode.AR); ScriptEventSystem.Instance.GoToLocation(selectedLocation); });
        Close.onClick.AddListener(delegate () { ShowDialog(false); });
        ScriptEventSystem.Instance.OnSetMode += OnSetMode;
        MapManager.Instance.location.OnLocationChanged += delegate (Vector2 v) { UpdateARButton(); };
    }

    private void OnSetMode(ScriptEventSystem.Mode m) {
        ShowDialog(false);
    }

    private void OnLocationPressed(Location l) {
        selectedLocation = l;
        Title.text = l.Title;
        Description.text = l.Description;
        Image.sprite = l.Image;
        ShowDialog(true);
        UpdateARButton();
    }

    private void UpdateARButton() {
        if (gameObject.activeInHierarchy) {
            Vector2 player = MapManager.Instance.location.position;
            Vector2 location = new Vector2((float)selectedLocation.Longitude, (float)selectedLocation.Latitude);
            float distance = OnlineMapsUtils.DistanceBetweenPoints(player, location).magnitude * 1000;
            //FarAwayText.text = distance + "m";
            //if (distance < selectedLocation.TriggerDistance) {
			if (true) {
                FarAwayText.gameObject.SetActive(false);
                ARMode.gameObject.SetActive(true);
            } else {
                FarAwayText.gameObject.SetActive(true);
                ARMode.gameObject.SetActive(false);
            }
        }
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