using UnityEngine;
using System.Collections;

public class Newsarticle : ScriptableObject {
    public string Link;
    public string Title;
    public string Timestamp;
    public double Latitude;
    public double Longitude;
    public string Description;
    public string ImageUrl;

    void OnEnable() {
        Longitude = 16.18 + Random.Range(-0.1f, 0.1f);
        Latitude = 58.589 + Random.Range(-0.1f, 0.1f);
    }

}
