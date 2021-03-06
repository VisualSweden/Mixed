﻿using UnityEngine;
using System.Collections;

[System.Serializable]
public class Location {
    public int ID;
    public string Title;
    public string Description;
    public Sprite Image;
    public Sprite MarkedPreviewImage;
    public Texture2D Thumbnail;
    public double Longitude;
    public double Latitude;
    public double TriggerDistance;
    public string ARDataset;
    public GameObject TrackedObject;
}