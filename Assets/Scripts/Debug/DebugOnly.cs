using UnityEngine;
using System.Collections;

public class DebugOnly : MonoBehaviour {
    void Start() {
        if (!Debug.isDebugBuild) {
            Destroy(gameObject);
        }

    }
}
