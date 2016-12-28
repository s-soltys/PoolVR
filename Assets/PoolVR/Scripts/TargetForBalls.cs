using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetForBalls : MonoBehaviour {
    void OnCollisionEnter(Collision target)
    {
        if (target.collider.tag == "Ball")
        {
            Debug.Log("DESTROYING BALL");
            Destroy(target.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ball")
        {
            Debug.Log("DESTROYING BALL");
            Destroy(collider.gameObject);
        }
    }
}
