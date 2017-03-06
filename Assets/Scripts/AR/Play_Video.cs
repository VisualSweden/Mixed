using UnityEngine;
using System.Collections;

public class Play_Video : MonoBehaviour {

    private MediaPlayerCtrl _mediaPlayer;
    private MeshRenderer _renderer;

    // Use this for initialization
    void Start()
    {
        _mediaPlayer = GetComponent<MediaPlayerCtrl>();
        GameObject targetPlane = _mediaPlayer.m_TargetMaterial[0];
        _renderer = targetPlane.GetComponent<MeshRenderer>();
        //_renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_renderer.enabled && !_mediaPlayer.enabled)
        {
            //_mediaPlayer.Play();
            _mediaPlayer.enabled = true;
        }
        else if (!_renderer.enabled && _mediaPlayer.enabled)
        {
            //_mediaPlayer.Stop();
            _mediaPlayer.enabled = false;
        }
    }
}
