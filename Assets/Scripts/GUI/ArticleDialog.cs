using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ArticleDialog : MonoBehaviour {
    public Text Title;
    public Text Description;

    public Button ReadMore;
    public Button Close;

    public Image articleImage;

    public GameObject MapControls;

    private Newsarticle Article;
    private Texture2D thumbnailTexture;

	void Start () {
        thumbnailTexture = new Texture2D(4, 4, TextureFormat.DXT1, false);
        ScriptEventSystem.Instance.OnArticlePressed += OnArticlePressed;
        gameObject.SetActive(false);
        //ReadMore.onClick.AddListener(delegate () { Application.OpenURL(Article.Link); });
        Close.onClick.AddListener(delegate () { ShowDialog(false); });
        ScriptEventSystem.Instance.OnSetMode += OnSetMode;

        ReadMore.onClick.AddListener(delegate () {
            ScriptEventSystem.Instance.SetMode(ScriptEventSystem.Mode.AR);
            ScriptEventSystem.Instance.EnterNewsARMode();
        });
    }

    private void OnSetMode(ScriptEventSystem.Mode m) {
        ShowDialog(false);
    }

    private void OnArticlePressed(Newsarticle article) {
        Article = article;
        Title.text = Article.Title;
        Description.text = Article.Description;
        ShowDialog(true);
        articleImage.enabled = false;
        if (article.ImageUrl != "")
            StartCoroutine(FetchImage());
    }


    private IEnumerator FetchImage() {
        WWW www = new WWW(Article.ImageUrl);
        yield return www;
        thumbnailTexture = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, false);
        www.LoadImageIntoTexture(thumbnailTexture);

        Rect rec = new Rect(0, 0, thumbnailTexture.width, thumbnailTexture.height);
        Sprite spriteToUse = Sprite.Create(thumbnailTexture, rec, new Vector2(0.5f, 0.5f), 100);
        articleImage.sprite = spriteToUse;

        www.Dispose();
        www = null;

        articleImage.enabled = true;
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

