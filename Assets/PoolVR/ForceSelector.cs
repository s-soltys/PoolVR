using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ForceSelector : MonoBehaviour
{
    private float cnt;
    public float speed;
    public float mod;
    public float str;
    public Image img;

    public float Strength
    {
        get { return str; }
    }

    public void Update()
    {
        cnt += speed * Time.deltaTime;

        mod = cnt % 2;

        str = mod < 1 ? mod : 2 - mod;

        img.fillAmount = str;
    }
}
