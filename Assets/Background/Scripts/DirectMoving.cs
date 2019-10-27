using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectMoving : MonoBehaviour
{
    public float speed;

    //moving the object with the defined speed
    private void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}