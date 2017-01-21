using UnityEngine;
using UnityEditor;
using NUnit.Framework;
using System;
using UniRx;
using HysteresisRes = HysteresisObservable.Result<float>;

public class HysteresisObservableShould
{
    [Test]
    public void GenerateSignalsStartingOutsideHysteresis()
    {
        var inputSequence = new float[] { 1, 2.5f, 2.51f, 3, 2, 0 };
        var enter = 2.5f;
        var exit = 0.5f;
        var initialState = false;

        HysteresisRes[] expectedResults = new HysteresisRes[]
        {
            new HysteresisRes(false, 1),
            new HysteresisRes(false, 2.5f),
            new HysteresisRes(true, 2.51f),
            new HysteresisRes(true, 3),
            new HysteresisRes(true, 2),
            new HysteresisRes(false, 0)
        };

        AssertHysteresisResult(inputSequence, enter, exit, initialState, expectedResults);
    }

    [Test]
    public void GenerateSignalsStartingInsideHysteresis()
    {
        var inputSequence = new float[] { 0.51f, 2, 3, 2, 0 };
        var enter = 2.5f;
        var exit = 0.5f;
        var initialState = true;

        HysteresisRes[] expectedResults = new HysteresisRes[]
        {
            new HysteresisRes(true, 0.51f),
            new HysteresisRes(true, 2),
            new HysteresisRes(true, 3),
            new HysteresisRes(true, 2),
            new HysteresisRes(false, 0)
        };

        AssertHysteresisResult(inputSequence, enter, exit, initialState, expectedResults);
    }

    private static void AssertHysteresisResult(float[] inputSequence, float enter, float exit, bool initialState, HysteresisRes[] expectedResults)
    {
        HysteresisRes[] actualResults = null;

        var sub = inputSequence
            .ToObservable()
            .Hysteresis(enter, exit, initialState)
            .ToArray()
            .Subscribe(results => actualResults = results);

        sub.Dispose();

        Assert.AreEqual(expectedResults.Length, actualResults.Length, "Actual and expected scores have different lengths");

        for (var i = 0; i < actualResults.Length; i++)
        {
            var msg = "Expected and actual differ on position " + i;
            Assert.AreEqual(expectedResults[i].IsThresholdReached, actualResults[i].IsThresholdReached, msg);
            Assert.AreEqual(expectedResults[i].Value, actualResults[i].Value, msg);
        }
    }
}
