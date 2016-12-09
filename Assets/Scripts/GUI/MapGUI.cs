using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapGUI : MonoBehaviour {
    private MapManager mapManager;

    public Button myPosition;
    public Button panorera;

	void Start () {
        mapManager = FindObjectOfType<MapManager>();
        myPosition.onClick.AddListener(delegate {
            mapManager.CenterOnPlayer();
        });
	}
}
