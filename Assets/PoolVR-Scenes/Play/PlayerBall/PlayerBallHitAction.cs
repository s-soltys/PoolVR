using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
[RequireComponent(typeof(Rigidbody))]
public class PlayerBallHitAction : MonoBehaviour
{
    public Transform direction;
    public float minStrength = 10;
    public float maxStrength = 180;

    public void Hit(float strengthPercent)
    {
        var force = Mathf.Lerp(minStrength, maxStrength, strengthPercent);

        GetComponent<Rigidbody>().AddForce(force * direction.forward, ForceMode.VelocityChange);
        
        GetComponent<AudioSource>().Play();
    }
    
}
