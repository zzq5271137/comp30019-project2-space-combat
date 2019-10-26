using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerCollision : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary")
            || other.gameObject.CompareTag("PlayerShot")
            || other.gameObject.CompareTag("EnemyShot")
            || other.tag.Equals("bonus")
            // || other.name.Equals("player")
            || other.gameObject.CompareTag("Player")
            || other.tag.Equals("coins")
        )
        {
        }
        else
        {
            Destroy(other.gameObject);
        }
    }
}