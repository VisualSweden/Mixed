using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LoadMainScene : MonoBehaviour {
	void Start () {
        Scene mainScene = SceneManager.GetSceneByName("MainScene");
        if (mainScene == null || !mainScene.isLoaded)
            SceneManager.LoadScene("MainScene");
	}
}
