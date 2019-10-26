using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class DestroyBigAsteroid : MonoBehaviour
{
    public GameObject explosion;
    public GameObject smallAsteroid;
    public int generatedSmallAsteroid;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
        }

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

        if (!other.gameObject.CompareTag("Player"))
        {
            int smallAsteroidNum = Random.Range(0, generatedSmallAsteroid);
            for (int i = 0; i < smallAsteroidNum; i++)
            {
                Instantiate(smallAsteroid, transform.position,
                    generateSmallAsteroidRotation(transform));
            }   
        }
    }

    private Quaternion generateSmallAsteroidRotation(Transform transform)
    {
        return new Quaternion(Random.Range(0, transform.rotation.x),
            0,
            Random.Range(0, transform.rotation.z),
            0);
    }
}