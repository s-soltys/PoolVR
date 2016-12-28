using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreViewer : MonoBehaviour {
    public ScoreCounter scoreCounter;

	void FixedUpdate () {
        GetComponent<Text>().text = scoreCounter.BallsLeft + " / " + scoreCounter.BallsTotal;
	}
}
