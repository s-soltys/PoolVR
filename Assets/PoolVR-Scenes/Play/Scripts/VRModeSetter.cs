using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class VRModeSetter : IInitializable
{
    [Inject]
    public AppSettings AppSettings { get; set; }

    [Inject]
    public GvrViewer GvrViewer { get; set; }
    
    void IInitializable.Initialize()
    {
        GvrViewer.VRModeEnabled = AppSettings.VRMode;
    }

}
