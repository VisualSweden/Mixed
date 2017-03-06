using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {
    public OnlineMaps map;
    public OnlineMapsLocationService location;

    public static MapManager Instance;

    public bool trackPlayer;

    public bool LimitLocation;

    public float maxLat;
    public float minLat;
    public float maxLng;
    public float minLng;

    public int maxZoom;
    public int minZoom;

    public float mapSnapBackDistance;

    public bool HasPosition;

    private Vector2 oldMapLocation;

    private OnlineMapsMarker3D playerMarker;
    public float interpolateSpeed;
    public Texture2D playerTexture;

    void Awake() {
        Instance = this;
        if (LimitLocation) {
            map.positionRange = new OnlineMapsPositionRange(minLat, minLng, maxLat, maxLng);
            map.zoomRange = new OnlineMapsRange(minZoom, maxZoom);
        }
        location.OnLocationInited += FirstLocationRecieved;

        playerMarker = FindObjectOfType<OnlineMapsTileSetControl>().markers3D[0];

    }

    private void Update() {
        if (playerMarker != null) {
            Vector2 goal = Vector2.Lerp(playerMarker.position, location.position, Time.deltaTime * interpolateSpeed);
            playerMarker.SetPosition(goal.x, goal.y);
            map.needRedraw = true;

            if (trackPlayer) {
                if ((map.position - oldMapLocation).magnitude > mapSnapBackDistance) {
                    PlayerMovedMap();
                } else {
                    map.SetPosition(goal.x, goal.y);
                    oldMapLocation = map.position;
                }
            }
        }
    }

    public void PlayerMovedMap() {
        ScriptEventSystem.Instance.PlayerMovesMap();
    }

    public void FirstLocationRecieved() {
        /*
        playerMarker = new OnlineMapsMarker();
        playerMarker.SetPosition(location.position.x, location.position.y);
        playerMarker.texture = playerTexture;
        playerMarker.Init();
        map.AddMarker(playerMarker);
        */
        HasPosition = true;
        map.SetPosition(location.position.x, location.position.y);
        playerMarker.SetPosition(location.position.x, location.position.y);
        location.OnLocationInited -= FirstLocationRecieved;
    }

    public void AddMarker(Location Location) {
        OnlineMaps map = FindObjectOfType<OnlineMaps>();
        OnlineMapsMarker marker = new OnlineMapsMarker();
        marker.SetPosition(Location.Longitude, Location.Latitude);
        marker.texture = Location.Thumbnail;
        marker.OnClick += delegate (OnlineMapsMarkerBase obj) { ScriptEventSystem.Instance.SelectedMapMarker(Location); };
        marker.Init();
        map.AddMarker(marker);
    }

    public void AddWebMarker(Newsarticle article, Texture2D ArticleTexture) {
        OnlineMaps map = FindObjectOfType<OnlineMaps>();
        OnlineMapsMarker marker = new OnlineMapsMarker();
        marker.SetPosition(article.Longitude, article.Latitude);
        marker.texture = ArticleTexture;
        //marker.OnClick += delegate (OnlineMapsMarkerBase obj) { Application.OpenURL(article.Link); };
        marker.OnClick += delegate (OnlineMapsMarkerBase obj) { ScriptEventSystem.Instance.SelectedNewsarticleMarker(article); };
        marker.Init();
        map.AddMarker(marker);
    }

    public void CenterOnPlayer(bool b) {
        trackPlayer = b;
        if (b) {
            //map.SetPosition(location.position.x, location.position.y);
            playerMarker.SetPosition(location.position.x, location.position.y);
            map.SetPosition(location.position.x, location.position.y);
            oldMapLocation = map.position;
            map.zoom = maxZoom;
        }
    }

    public bool PlayerInRange() {
        if (LimitLocation)
            return location.position.x > minLng && location.position.x < maxLng && location.position.y > minLat && location.position.y < maxLat;
        return true;
    }
}