using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class ScoreCounter : MonoBehaviour
{
    [Inject]
    public StageStats Stats { get; private set; }

    void Start() {
        Stats.BallsTotal = Stats.BallsLeft = GetComponentsInChildren<Rigidbody>().Length;
        StartCoroutine(Count());
	}

    IEnumerator Count()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            Stats.BallsLeft = GetComponentsInChildren<Rigidbody>().Length;
        }
    }
	
}
