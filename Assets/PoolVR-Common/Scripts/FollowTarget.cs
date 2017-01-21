using System;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using Zenject;

public class FollowTarget : MonoBehaviour
{
    [Inject]
    public ForceSelector ForceSelector { get; set; }

    public Rigidbody targetRb;
    public float velocityThresh;
    public float moveToTargetSpeed;
    public float distanceToResume;
    public float distanceToReset;
    private IDisposable sub;

    void Start()
    {
        sub = Observable
            .IntervalFrame(5)
            .Select(_ => Vector3.Distance(targetRb.transform.position, transform.position))
            .Hysteresis((d, referenceDist) => d - referenceDist, distanceToResume, distanceToReset)
            .Subscribe(isMoving =>
            {
                ForceSelector.IsRunning = !isMoving;
            });
    }

    void OnDestroy()
    {
        if (sub != null)
        {
            sub.Dispose();
            sub = null;
        }
    }

    void Update ()
    {
        if (targetRb.velocity.magnitude < velocityThresh && !ForceSelector.IsRunning)
        {
            transform.position = Vector3.Lerp(transform.position, targetRb.transform.position, moveToTargetSpeed);
        }

	}

}
