using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadScenes : MonoBehaviour {
    public string[] Scenes;

    private static bool doOnce;

    void Awake() {
        if (!doOnce) {
            doOnce = true;
            foreach (var scene in Scenes) {
                SceneManager.LoadScene(scene, LoadSceneMode.Additive);
            }
        }
    }
}
