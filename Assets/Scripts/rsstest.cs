using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.Xml;

public class rsstest : MonoBehaviour {
    private bool isInsideItem;
    private Newsarticle currentArticle;

    public string url = "http://www.nt.se/nyheter/norrkoping/rss/";

    IEnumerator Start() {
        WWW www = new WWW(url);
        yield return www;
        List<Newsarticle> articles = Parse(www.text);
        //List<Newsarticle> articles = new List<Newsarticle>();

        TextAsset gpsLocations = Resources.Load<TextAsset>("gps_tagged_news");
        List<Newsarticle> articles2 = Parse(gpsLocations.text);
        foreach(Newsarticle article in articles2) {
            articles.Add(article);
        }
        foreach(Newsarticle article in articles) {
            MapManager.Instance.AddWebMarker(article);
        }
    }

    private List<Newsarticle> Parse(string s) {
        List<Newsarticle> articles = new List<Newsarticle>();
        var reader = new TinyXmlReader(s);
        while (reader.Read()) {
            if (isInsideItem) {
                if (currentArticle == null) {
                    currentArticle = Newsarticle.CreateInstance<Newsarticle>();

                } else if (reader.isOpeningTag && reader.tagName == "item" && currentArticle) { // New article
                    articles.Add(currentArticle);
                    currentArticle = Newsarticle.CreateInstance<Newsarticle>();
                }

                if (reader.isOpeningTag) {
                    switch (reader.tagName) {
                        case "link":
                            currentArticle.Link = reader.content;
                            break;
                        case "title":
                            currentArticle.Title = reader.content;
                            break;
                        case "pubDate":
                            currentArticle.Timestamp = reader.content;
                            break;
                        case "longitude":
                            currentArticle.Longitude = double.Parse(reader.content);
                            break;
                        case "latitude":
                            currentArticle.Latitude = double.Parse(reader.content);
                            break;
                        case "description":
                            currentArticle.Description = reader.content;
                            break;
                        default:
                            break;
                    }
                }
            } else {
                if (reader.isOpeningTag && reader.tagName == "item") {
                    isInsideItem = true;
                }
            }
        }
        if (currentArticle)
            articles.Add(currentArticle);
        return articles;
    }
}