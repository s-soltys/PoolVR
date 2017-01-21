using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ForceSelectorView : MonoBehaviour
{
    [Inject]
    public ForceSelector ForceSelector { get; set; }
    
    public Image img;

    void Update()
    {
        img.fillAmount = ForceSelector.Strength;
    }

}
