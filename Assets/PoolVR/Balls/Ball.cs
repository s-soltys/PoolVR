using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    AudioSource audioSource;

    void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

	void OnCollisionEnter(Collision collision)
    {
        var targetAudio = collision.collider ? collision.collider.GetComponent<AudioSource>() : null;

        if (!audioSource.isPlaying && (!targetAudio || !targetAudio.isPlaying))
        {
            audioSource.volume = Mathf.InverseLerp(5, 30, collision.relativeVelocity.magnitude);
            audioSource.Play();
        }
	}
}
