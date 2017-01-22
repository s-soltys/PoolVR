using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class ForceSelectorStateMediator : MonoBehaviour
{
    [Inject]
    public ForceSelector ForceSelector { get; set; }

    public Rigidbody targetRb;
    public float distanceToResume;
    public float distanceToReset;
    private IDisposable sub;

    void Start()
    {
        sub = Observable
            .IntervalFrame(5)
            .Select(_ => Vector3.Distance(targetRb.transform.position, transform.position))
            .Hysteresis(distanceToResume, distanceToReset)
            .Select(hysteresisResult => hysteresisResult.IsThresholdReached)
            .Subscribe(isMoving =>
            {
                ForceSelector.IsActive = !isMoving;
            });
    }

    void OnDestroy()
    {
        if (sub != null)
        {
            sub.Dispose();
            sub = null;
        }
    }
}
