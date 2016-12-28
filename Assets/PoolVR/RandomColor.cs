using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomColor : MonoBehaviour {
    public Color[] randomColors;
    
	void Awake () {
        GetComponent<Renderer>().material.color = randomColors[Random.Range(0, randomColors.Length)];
	}
	
}
