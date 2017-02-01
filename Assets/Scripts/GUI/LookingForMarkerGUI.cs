using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LookingForMarkerGUI : MonoBehaviour {

    public Image Marker;

    void Start() {
        ScriptEventSystem.Instance.OnGoToLocation += GoToLocation;
        AREventSystem.Instance.OnSetMode += SetARMode;

        gameObject.SetActive(false);
    }

    private void SetARMode(AREventSystem.ARMode m) {
        gameObject.SetActive(m == AREventSystem.ARMode.LookingForMarker);
    }

    private void GoToLocation(Location l) {
        if (l.MarkedPreviewImage != null) {
            Marker.sprite = l.MarkedPreviewImage;
            AREventSystem.Instance.SetMode(AREventSystem.ARMode.LookingForMarker);
        }
    }
}
