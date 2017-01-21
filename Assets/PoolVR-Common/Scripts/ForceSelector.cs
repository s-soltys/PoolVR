using UnityEngine;
using System.Collections;
using UniRx;
using System;

public class ForceSelector : IDisposable
{
    private bool isRunning;
    private IObservable<float> traingleSignal;
    private IDisposable sub;

    public float Strength { get; private set; }

    public bool IsRunning
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

    public ForceSelector(IObservable<float> traingleSignal)
    {
        this.traingleSignal = traingleSignal;
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

        if (IsRunning)
        {
            sub = traingleSignal.Subscribe(x =>
            {
                Strength = x;
            });
        }
        else
        {
            DisposeSubscription();
        }
    }
}
