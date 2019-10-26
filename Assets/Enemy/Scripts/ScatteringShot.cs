using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScatteringShot : MonoBehaviour
{
    public GameObject shot;
    public int num;
    public Transform shotSpawn;
    public float fireRate;
    public float delay;

    void Start()
    {
        InvokeRepeating("Fire", delay, fireRate);
    }

    void Fire()
    {
        float segment = 360 / num;
        float angle = 270;
        for (int i = 0; i < num; i++)
        {
            Instantiate(shot, shotSpawn.position,
                Quaternion.Euler(0, angle, 0));
            angle += segment;
        }
    }
}