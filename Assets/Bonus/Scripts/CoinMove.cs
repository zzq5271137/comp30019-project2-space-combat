using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMove : MonoBehaviour
{
    public int speed = -5;

    public int angular = 5;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
        GetComponent<Rigidbody>().angularVelocity =
            Random.insideUnitSphere * angular;
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}