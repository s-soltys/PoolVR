using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class VRModeSetter : MonoBehaviour
{
    [Inject]
    public AppSettings AppSettings { get; set; }

    [Inject]
    public GvrViewer GvrViewer { get; set; }

    public Canvas VrCanvas;
    public Canvas Canvas;
    private IDisposable sub;

    void Start()
    {
        var sub = ObservableSignals.GetDistinctPropertyUntilChangedOnUpdate(() => AppSettings.VRMode).Subscribe(UpdateVRMode);
    }

    void OnDestroyed()
    {
        if (sub != null)
        {
            sub.Dispose();
            sub = null;
        }
    }

    private void UpdateVRMode(bool vrModeEnabled)
    {
        GvrViewer.VRModeEnabled = vrModeEnabled;
        VrCanvas.gameObject.SetActive(vrModeEnabled);
        Canvas.gameObject.SetActive(!vrModeEnabled);
    }

}
