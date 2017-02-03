using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class SummaryViewer : MonoBehaviour
{
    [Inject]
    public StageStatistics Stats { get; private set; }

    public Text label;
    public GameObject[] uiElements;
    private IDisposable sub;

    public void Start()
    {
        sub = Observable
            .EveryFixedUpdate()
            .Select(_ => Stats.Completed)
            .Where(c => c == true)
            .First()
            .Subscribe(_ =>
            {
                ShowSummary();
            });
    }

    public void OnDestroy()
    {
        if (sub != null)
        {
            sub.Dispose();
            sub = null;
        }
    }
    
    private void ShowSummary()
    {
        foreach (var elem in uiElements)
        {
            elem.SetActive(true);
        }

        label.text = string.Format(@"Finished in {0} hits!
Well done!", Stats.Hits);
    }
}
