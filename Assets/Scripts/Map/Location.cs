using UnityEngine;
using System.Collections;

[System.Serializable]
public class Location {
    public string Title;
    public string Description;
    public Sprite Image;
    public Sprite MarkedPreviewImage;
    public Texture2D Thumbnail;
    public double Longitude;
    public double Latitude;
    public double TriggerDistance;
}