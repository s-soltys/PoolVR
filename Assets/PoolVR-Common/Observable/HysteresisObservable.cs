using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public static class HysteresisObservable
{
    public static IObservable<Result<T>> Hysteresis<T>(this IObservable<T> source, T enter, T exit, bool initialState = false)
        where T : IComparable 
    {
        return source.Hysteresis(enter, exit, (value, threshold) => value.CompareTo(threshold) > 0, initialState);
    }

    public static IObservable<Result<T>> Hysteresis<T>(this IObservable<T> source, T enter, T exit, Func<T, T, bool> compare, bool initialState = false)
    {
        return source.Scan(
           new Result<T>(initialState, default(T)),
           (acc, value) =>
           {
               var threshold = acc.IsThresholdReached ? exit : enter;
               var isThresholdReached = compare(value, threshold);
               return new Result<T>(isThresholdReached, value);
           });
    }

    public class Result<T>
    {
        public readonly bool IsThresholdReached;
        public readonly T Value;

        public Result(bool isThresholdReached, T value)
        {
            this.IsThresholdReached = isThresholdReached;
            this.Value = value;
        }
    }
}
