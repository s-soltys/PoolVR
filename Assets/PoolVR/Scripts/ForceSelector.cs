using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

public class ForceSelector : MonoBehaviour
{
    public float period;
    public Image img;

    public float Strength { get; private set; }

    void Start()
    {
        CreateTriangleSignal(period).Subscribe(x =>
        {
            img.fillAmount = Strength = x;
        });
    }

    public static IObservable<float> CreateTriangleSignal(float period)
    {
        return Observable.IntervalFrame(1, FrameCountType.Update)
            .Scan(0f, (c, _) => c + Time.deltaTime)
            .Select(t => (period - Mathf.Abs(t % (2 * period) - period)) / period);
    }
}
