using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class FollowTarget : MonoBehaviour
{
    [Inject]
    public ForceSelector ForceSelector { get; set; }

    public Rigidbody targetRb;
    public float distanceToReset = 0.1f;
    public float velocityThresh;
    public float moveToTargetSpeed;
    public bool isAtTarget;
    
    void Update ()
    {
        isAtTarget = Vector3.Distance(targetRb.transform.position, transform.position) <= distanceToReset;
        
        if (targetRb.velocity.magnitude < velocityThresh && !isAtTarget)
        {
            transform.position = Vector3.Lerp(transform.position, targetRb.transform.position, moveToTargetSpeed);
        }

        ForceSelector.IsRunning = isAtTarget;
	}
}
