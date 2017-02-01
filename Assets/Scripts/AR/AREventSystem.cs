using UnityEngine;
using System.Collections;

public class AREventSystem : MonoBehaviour {
    public delegate void modeDelegate(ARMode m);
    public delegate void mediaPlayerDelegate(MediaPlayerCtrl m);

    public event modeDelegate OnSetMode;
    public event ScriptEventSystem.locatiodDeletage OnFoundTrackedLocation;
    public event ScriptEventSystem.locatiodDeletage OnLostTrackedLocation;
    public event mediaPlayerDelegate OnLostTrackedMovie;
    public event mediaPlayerDelegate OnFoundTrackedMovie;

    public static AREventSystem Instance;

    public ARMode CurrentMode;

    public enum ARMode {
        NotInAR,
        PureAR,
        VideoPlayer,
        LookingForMarker
    }

    void Awake() {
        Instance = this;
    }

    void Start() {
        ScriptEventSystem.Instance.OnSetMode += SetAppMode;
    }

    private void SetAppMode(ScriptEventSystem.Mode m) {
        if (m != ScriptEventSystem.Mode.AR)
            SetMode(ARMode.NotInAR);
    }

    public void SetMode(ARMode m) {
        if (OnSetMode != null)
            OnSetMode(m);
        CurrentMode = m;
    }

    public void FoundTrackedLocation(Location l) {
        if (OnFoundTrackedLocation != null)
            OnFoundTrackedLocation(l);
        SetMode(ARMode.PureAR);
    }

    public void LostTrackedLocation(Location l) {
        if (OnLostTrackedLocation != null )
            OnLostTrackedLocation(l);
        SetMode(ARMode.LookingForMarker);
    }

    public void LostTrackedMovie(MediaPlayerCtrl movie) {
        if (OnLostTrackedMovie != null )
            OnLostTrackedMovie(movie);
        SetMode(ARMode.PureAR);
    }

    public void FoundTrackedMovie(MediaPlayerCtrl movie) {
        if (OnFoundTrackedMovie != null )
            OnFoundTrackedMovie(movie);
        SetMode(ARMode.VideoPlayer);
    }
}