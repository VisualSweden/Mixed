using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WebImage : MonoBehaviour {
    private Image image;
    private string imageUrl;
    private Texture2D texture;

	void Awake () {
        image = GetComponent<Image>();
	}

    public void LoadImage(string url) {
        StopAllCoroutines();
        imageUrl = url;
        StartCoroutine(FetchImage());
    }
	
    private IEnumerator FetchImage() {
        WWW www = new WWW(imageUrl);
        yield return www;
        if (www.texture) {
            texture = new Texture2D(www.texture.width, www.texture.height, TextureFormat.DXT1, false);
            www.LoadImageIntoTexture(texture);

            Rect rec = new Rect(0, 0, texture.width, texture.height);
            Sprite spriteToUse = Sprite.Create(texture, rec, new Vector2(0.5f, 0.5f), 100);
            image.sprite = spriteToUse;
        }
        www.Dispose();
        www = null;
    }
}
