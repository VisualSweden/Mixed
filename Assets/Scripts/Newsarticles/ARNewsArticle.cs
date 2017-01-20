using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ARNewsArticle : MonoBehaviour {
    public Text Title;
    public Text Date;
    public WebImage Image;
    public Button Button;

    private Newsarticle article;

    public void SetArticle(Newsarticle article) {
        Title.text = article.Title;
        Date.text = article.Timestamp;
        this.article = article;
        if (article.ImageUrl != "")
            Image.LoadImage(article.ImageUrl);
        gameObject.SetActive(true);
    }

	void Start () {

        // Set event camera
        GetComponentInChildren<Canvas>().worldCamera = FindObjectOfType<GyroscopeCamera>().GetComponent<Camera>();

        ScriptEventSystem.Instance.OnSetMode += Instance_OnSetMode;
		Vector3 pos = Quaternion.Euler (0, Random.Range(0,360), 0) * Vector3.forward * 5;
        pos.y = Random.Range(-1, 4);
		transform.position = pos;
        Button.onClick.AddListener(delegate () { Application.OpenURL(article.Link); });
	}

    private void Instance_OnSetMode(ScriptEventSystem.Mode m) {
        if (m != ScriptEventSystem.Mode.AR) {
            Destroy(gameObject);
        }
    }

    public void Update() {
    } 
}
