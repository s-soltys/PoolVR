using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    public int BallsLeft { get; private set; }
    public int BallsTotal { get; private set; }
    
    void Awake () {
        BallsTotal = BallsLeft = GetComponentsInChildren<Rigidbody>().Length;
        StartCoroutine(Count());
	}

    IEnumerator Count()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            BallsLeft = GetComponentsInChildren<Rigidbody>().Length;
        }
    }
	
}
