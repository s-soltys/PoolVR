using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class FollowPlayerBall : MonoBehaviour
{
    [Inject]
    public ForceSelector ForceSelector { get; set; }

    public Rigidbody targetRb;
    public float velocityThresh;
    public float moveToTargetSpeed;

    void Update ()
    {
        if (targetRb.velocity.magnitude < velocityThresh && !ForceSelector.IsActive)
        {
            transform.position = Vector3.Lerp(transform.position, targetRb.transform.position, moveToTargetSpeed);
        }
	}

}
