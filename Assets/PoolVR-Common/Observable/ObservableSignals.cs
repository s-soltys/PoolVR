using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public static class ObservableSignals
{
    public static IObservable<float> CreateTriangleSignal(float period)
    {
        return Observable.IntervalFrame(1, FrameCountType.Update)
            .Scan(0f, (c, _) => c + Time.deltaTime)
            .Select(t => (period - Mathf.Abs(t % (2 * period) - period)) / period);
    }

    public static IObservable<T> GetDistinctPropertyUntilChangedOnUpdate<T>(Func<T> selector)
    {
        return Observable.EveryUpdate()
            .Select(_ => selector())
            .StartWith(selector())
            .DistinctUntilChanged();
    }
}
