using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MemoryUsed : MonoBehaviour {
    private Text text;
    void Start() {
        if (Debug.isDebugBuild) {
            text = GetComponent<Text>();
            Profiler.enabled = true;
        } else {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update() {
        text.text = "Allocated: " + Profiler.GetTotalAllocatedMemory() / 1000000 + " MB\nReserved: " + Profiler.GetTotalReservedMemory() / 1000000 + " MB";
    }
}
