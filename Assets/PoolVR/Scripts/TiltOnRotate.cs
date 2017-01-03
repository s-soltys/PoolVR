using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiltOnRotate : MonoBehaviour {
    public Vector2 scale;

	void Update () {
        var rotation = transform.localRotation.eulerAngles;
        
        transform.localPosition = new Vector3(
            scale.x * Mathf.DeltaAngle(rotation.z, 0) / 180,
            scale.y * Mathf.DeltaAngle(rotation.x, 0) / 180,
            0
            );
	}
}
