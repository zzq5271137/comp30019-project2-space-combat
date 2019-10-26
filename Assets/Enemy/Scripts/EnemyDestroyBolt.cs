using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestroyBolt : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary")
            || other.gameObject.CompareTag("EnemyShot")
            || other.gameObject.CompareTag("Enemy")
            || other.gameObject.CompareTag("Boss")
            || other.gameObject.CompareTag("PlayerShot")
            || other.gameObject.CompareTag("Asteroid")
            || other.gameObject.CompareTag("SmallAsteriod")
            || other.gameObject.CompareTag("coins")
            || other.gameObject.CompareTag("bonus")
        )
        {
            return;
        }

        Destroy(gameObject);
    }
}