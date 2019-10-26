using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
    // destroy the object that collides with this object
    void OnTriggerEnter(Collider other)
    {
        Debug.Log("destroy this bullet");
    }
    
    // prevent leak
    void OnBecameInvisible() {
        Destroy(gameObject);
    }
}
