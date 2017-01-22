using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

public class ScoreCounter : MonoBehaviour
{
    [Inject]
    public StageStatistics Stats { get; private set; }

    [Inject]
    public GameplayCompleteAction GameplayCompleteAction { get; private set; }

    public int checkFrequencyInSeconds = 1;

    void Start() {
        Stats.BallsTotal = Stats.BallsLeft = NumberOfBallsLeft;
        StartCoroutine(Count());
	}

    IEnumerator Count()
    {
        while (true)
        {
            yield return new WaitForSeconds(checkFrequencyInSeconds);
            Stats.BallsLeft = NumberOfBallsLeft;

            if (Stats.BallsLeft == 0)
            {
                GameplayCompleteAction.Completed();
            }
        }
    }

    private int NumberOfBallsLeft
    {
        get
        {
            return GetComponentsInChildren<Rigidbody>().Length;
        }
    }
	
}
