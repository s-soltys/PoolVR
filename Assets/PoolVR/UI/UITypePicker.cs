using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class UITypePicker : MonoBehaviour {
    [Inject]
    public GvrViewer GvrViewer { get; set; }

    public Canvas VrCanvas;
    public Canvas Canvas;

    void Start()
    {
        GvrViewer.VRModeEnabled = AppSettings.VRMode;
        UpdateState();
    }

    void FixedUpdate ()
    {
        UpdateState();
    }

    private void UpdateState()
    {
        VrCanvas.gameObject.SetActive(GvrViewer.VRModeEnabled);
        Canvas.gameObject.SetActive(!GvrViewer.VRModeEnabled);
    }

}
