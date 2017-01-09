using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MapGUI : MonoBehaviour {
    private MapManager mapManager;

    public Toggle myPosition;

	void Start () {
        mapManager = FindObjectOfType<MapManager>();
        myPosition.onValueChanged.AddListener(delegate (bool v) {
            mapManager.CenterOnPlayer(v);
        });

        ScriptEventSystem.Instance.OnPlayerMovesMap += delegate {
            myPosition.isOn = false;
        };
    }
}