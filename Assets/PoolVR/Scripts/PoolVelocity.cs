using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PoolVelocity : MonoBehaviour
{
    [Inject]
    public ForceSelector ForceSelector { get; set; }

    [Inject]
    public StageStats Stats { get; private set; }

    public Transform direction;
    public float minStrength;
    public float maxStrength;
	
	void Update ()
    {
	    if (ForceSelector.IsRunning && Input.GetMouseButton(0))
        {
            var force = Mathf.Lerp(minStrength, maxStrength, ForceSelector.Strength);
            GetComponent<Rigidbody>().AddForce(force * direction.forward, ForceMode.VelocityChange);
            StartCoroutine(Disable());

            GetComponent<AudioSource>().Play();

            Stats.Hits += 1;
        }	
	}

    IEnumerator Disable()
    {
        enabled = false;
        yield return new WaitForSeconds(1);
        enabled = true;
    }
}
