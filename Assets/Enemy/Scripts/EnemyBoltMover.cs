using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoltMover : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
    }
}