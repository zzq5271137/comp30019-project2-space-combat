using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDestroyBolt : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary")
            || other.gameObject.CompareTag("EnemyShot")
            || other.gameObject.CompareTag("PlayerShot")
            || other.tag.Equals("bonus")
            // || other.name.Equals("player")
            || other.gameObject.CompareTag("Player")
            || other.tag.Equals("coins")
        )
        {
            return;
        }

        Destroy(gameObject);
    }
}