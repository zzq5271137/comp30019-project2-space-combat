using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerControl : MonoBehaviour
{
    private int speed = 0;
    public float yPosition = 0;
    private float angle = 0;
    private PlayerInputControl _player;


    private void Start()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            _player = playerObject.GetComponent<PlayerInputControl>();
            this.speed = _player.speed;
            this.yPosition = _player.yPosition;
            this.angle = _player.angle;
        }

        if (playerObject == null)
        {
            Debug.Log("Cannot find 'player' script");
        }
    }

    void FixedUpdate()
    {
        GetComponent<Rigidbody>().position = new Vector3(
            _player.transform.position.x,
            _player.transform.position.y,
            _player.transform.position.z+1.5f);
    }
}