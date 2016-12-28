using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    public Rigidbody targetRb;
    public float velocityThresh;
    public float moveToTargetSpeed;
    
	void Update () {
		if (targetRb.velocity.magnitude < velocityThresh)
        {
            transform.position = Vector3.Lerp(transform.position, targetRb.transform.position, moveToTargetSpeed);
        }
	}
}
