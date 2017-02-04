using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class HitsMadeLabel : MonoBehaviour
{
    [Inject]
    public StageStatistics Stats { get; private set; }

    void FixedUpdate()
    {
        GetComponent<Text>().text = Stats.Hits + " Hits";
    }
}
