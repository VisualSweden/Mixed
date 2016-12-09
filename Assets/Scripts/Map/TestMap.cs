using UnityEngine;
using System.Collections;

public class TestMap : MonoBehaviour {

    OnlineMaps map;
	// Use this for initialization
	void Start () {
        map = FindObjectOfType<OnlineMaps>();
        map.markers[0].OnPress += delegate { test(); };
        map.markers[0].OnClick += delegate { test(); };
        map.markers[1].OnClick += delegate { test(); };
	}
	

    void test() {
        Debug.Log("TEST!");

    }
}
