using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiralMotion : MonoBehaviour
{
    public float speed;
    public float rotation;

    void Update()
    {
        if (rotation == 360)
            rotation = 0;
        rotation = rotation + 150 * Time.deltaTime;
//        speed = speed + 2 * Time.deltaTime;
        gameObject.transform.rotation = Quaternion.Euler(0, rotation, 0);
        gameObject.transform.Translate(speed, 0, speed);
    }
}