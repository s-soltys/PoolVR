using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantAngleRotation : MonoBehaviour {
    public Vector3 directionEuler;

	void Update () {
        transform.Rotate(Time.deltaTime * directionEuler);
	}
}
