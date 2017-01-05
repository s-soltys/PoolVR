using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShrinkAndDestroy : MonoBehaviour
{
    public float shrinkSpeed;
    
	void Update ()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, shrinkSpeed);
	}
    
    public static void GameObject(GameObject gameObject, float destroyDelay, float shrinkSpeed)
    {
        Destroy(gameObject, destroyDelay);

        var component = gameObject.AddComponent<ShrinkAndDestroy>();
        component.shrinkSpeed = shrinkSpeed;
    }
}
