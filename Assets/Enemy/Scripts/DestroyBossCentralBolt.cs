using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBossCentralBolt : MonoBehaviour
{
    public GameObject explosion;
    public GameObject smallBolt;
    public int generatedSmallBolt;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary")
            || other.gameObject.CompareTag("EnemyShot")
            || other.gameObject.CompareTag("Enemy")
            || other.gameObject.CompareTag("Boss")
            || other.gameObject.CompareTag("Asteroid")
            || other.gameObject.CompareTag("SmallAsteriod")
            || other.gameObject.CompareTag("coins")
            || other.gameObject.CompareTag("bonus")
        )
        {
            return;
        }

        Instantiate(explosion, transform.position, transform.rotation);
        Destroy(gameObject);
//        Destroy(other.gameObject);

        float segment = 360 / generatedSmallBolt;
        float angle = 270;
        for (int i = 0; i < generatedSmallBolt; i++)
        {
            Instantiate(smallBolt, gameObject.transform.position,
                Quaternion.Euler(0, angle, 0));
            angle += segment;
        }
    }
}