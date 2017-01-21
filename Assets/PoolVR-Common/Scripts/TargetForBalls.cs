using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetForBalls : MonoBehaviour {
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Ball")
        {
            GetRidOfBall(collision.collider.gameObject);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ball")
        {
            GetRidOfBall(collider.gameObject);
        }
    }

    private void GetRidOfBall(GameObject ballGameObject)
    {
        GetComponent<AudioSource>().Play();
        ShrinkAndDestroy.GameObject(ballGameObject, 0.25f, 0.5f);
    }
}
