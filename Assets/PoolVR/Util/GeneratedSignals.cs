using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public static class GeneratedSignals
{
    public static IObservable<float> CreateTriangleSignal(float period)
    {
        return Observable.IntervalFrame(1, FrameCountType.Update)
            .Scan(0f, (c, _) => c + Time.deltaTime)
            .Select(t => (period - Mathf.Abs(t % (2 * period) - period)) / period);
    }

    public static IObservable<bool> Hysteresis<T>(this IObservable<T> obs, Func<T, T, float> compare, T enter, T exit, bool initialState = false)
    {
        return obs.Scan(initialState, (state, value) =>
        {
            var switchState = (state && compare(value, exit) < 0) || (!state && compare(value, enter) > 0);
            return switchState ? !state : state;
        })
        .DistinctUntilChanged();
    }
}
