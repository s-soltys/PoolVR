using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class ScoreViewer : MonoBehaviour
{
    [Inject]
    public StageStats Stats { get; private set; }

    void FixedUpdate()
    {
        GetComponent<Text>().text = string.Format(@"Hits: {0}
Left: {1}", Stats.Hits, Stats.BallsLeft);
	}
}
