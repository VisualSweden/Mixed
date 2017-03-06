using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DebugPrintLocation : MonoBehaviour {

    private Text text;
    private OnlineMapsLocationService location;

    void Start() {
        if (Debug.isDebugBuild) {
            text = GetComponent<Text>();
            location = MapManager.Instance.location;
        } else {
            Destroy(gameObject);
        }
    }

    void Update() {
        text.text = "Lng " + location.position.x + "\nLat " + location.position.y;
    }
}
