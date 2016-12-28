using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolVelocity : MonoBehaviour {
    public ForceSelector forceSelector;
    public Transform direction;
    public float minStrength;
    public float maxStrength;
	
	void Update () {
	    if (Input.GetMouseButton(0))
        {
            var force = Mathf.Lerp(minStrength, maxStrength, forceSelector.Strength);
            GetComponent<Rigidbody>().AddForce(force * direction.forward, ForceMode.VelocityChange);
            StartCoroutine(Disable());

            GetComponent<AudioSource>().Play();
        }	
	}

    IEnumerator Disable()
    {
        enabled = false;
        yield return new WaitForSeconds(1);
        enabled = true;
    }
}
