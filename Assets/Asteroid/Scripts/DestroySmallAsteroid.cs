using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySmallAsteroid : MonoBehaviour
{
    public GameObject explosion;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary") ||
            other.gameObject.CompareTag("Asteroid") ||
            other.gameObject.CompareTag("SmallAsteriod") ||
            other.gameObject.CompareTag("Enemy") ||
            other.gameObject.CompareTag("Boss") ||
            other.gameObject.CompareTag("EnemyShot") ||
            other.gameObject.CompareTag("bonus") ||
            other.gameObject.CompareTag("coins")
        )
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}