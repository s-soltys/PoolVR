using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class FloatExtensions
{
    public static float Remap(this float value, float fromA, float fromB, float toA, float toB)
    {
        return Mathf.Lerp(toA, toB, Mathf.InverseLerp(fromA, fromB, value));
    }
}
