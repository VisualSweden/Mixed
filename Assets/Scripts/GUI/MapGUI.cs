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
            if (v) {
                myPosition.isOn = true;
            }
        });
        //mapManager.map.OnChangePosition += delegate () { Debug.Log("PING"); };
    }
}