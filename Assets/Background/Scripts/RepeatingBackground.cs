using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    public float verticalSize;

    private void Update()
    {
        if (transform.position.z < -verticalSize)
        {
            RepositionBackground();
        }
    }

    void RepositionBackground()
    {
        Vector3 groundOffSet = new Vector3(0, 0, verticalSize * 2f);
        transform.position = transform.position + groundOffSet;
    }
}