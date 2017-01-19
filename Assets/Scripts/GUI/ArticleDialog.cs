using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArticleDialog : MonoBehaviour {
    public Text Title;
    public Text Description;

    public Button ReadMore;
    public Button Close;

    public GameObject MapControls;

    private Newsarticle Article;

	void Start () {
        ScriptEventSystem.Instance.OnArticlePressed += OnArticlePressed;
        gameObject.SetActive(false);
        ReadMore.onClick.AddListener(delegate () { Application.OpenURL(Article.Link); });
        Close.onClick.AddListener(delegate () { ShowDialog(false); });
        ScriptEventSystem.Instance.OnSetMode += OnSetMode;
    }

    private void OnSetMode(ScriptEventSystem.Mode m) {
        ShowDialog(false);
    }

    private void OnArticlePressed(Newsarticle article) {
        Article = article;
        Title.text = Article.Title;
        Description.text = Article.Description;
        ShowDialog(true);
    }

    private void ShowDialog(bool show) {
        if (show) {
            gameObject.SetActive(true);
            MapControls.SetActive(false);
        } else {
            gameObject.SetActive(false);
            MapControls.SetActive(true);
        }
    }
}

