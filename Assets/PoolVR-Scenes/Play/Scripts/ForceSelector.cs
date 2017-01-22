using UnityEngine;
using System.Collections;
using UniRx;
using System;

public class ForceSelector : IDisposable
{
    private bool isRunning;
    private IObservable<float> triangleSignal;
    private IDisposable sub;

    public float Strength { get; private set; }

    public bool IsActive
    {
        get
        {
            return isRunning;
        }
        set
        {
            if (isRunning != value)
            {
                isRunning = value;
                UpdateIsRunningStatus();
            }
        }
    }

    public ForceSelector(float triangleSignalPeriod)
    {
        this.triangleSignal = ObservableSignals.CreateTriangleSignal(triangleSignalPeriod);
    }

    void DisposeSubscription()
    {
        if (sub != null)
        {
            sub.Dispose();
            sub = null;
        }
    }

    void IDisposable.Dispose()
    {
        DisposeSubscription();
    }

    private void UpdateIsRunningStatus()
    {
        Strength = 0f;

        if (IsActive)
        {
            sub = triangleSignal.Subscribe(s => Strength = s);
        }
        else
        {
            DisposeSubscription();
        }
    }
}
