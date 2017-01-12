using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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

            if (Stats.BallsLeft == 0)
            {
                SceneManager.LoadScene("MainMenu");
            }
        }
    }
	
}
