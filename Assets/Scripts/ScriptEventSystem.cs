using UnityEngine;
using System.Collections;

public class ScriptEventSystem : MonoBehaviour {
    public delegate void voidDeletage();
    public delegate void booldDeletage(bool b);

    public event booldDeletage OnSetARMode;

    public static ScriptEventSystem Instance;

    void Awake() {
        Instance = this;
    }

    public void SetARMode(bool arModeOn) {
        if (OnSetARMode != null)
            OnSetARMode(arModeOn);
    }
}
