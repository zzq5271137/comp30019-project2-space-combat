using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionForRayBonus : MonoBehaviour
{
    private PlayerInputControl _player;
    private int bolt_type = 2;

    private void OnTriggerEnter(Collider other)
    {
        // if (other.name.Equals("player"))
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject playerObject =
                GameObject.FindGameObjectWithTag("Player");
            if (playerObject != null)
            {
                _player = playerObject.GetComponent<PlayerInputControl>();
            }

            if (playerObject == null)
            {
                Debug.Log("Cannot find 'player' script");
            }

            Destroy(this.gameObject);

            _player.destroyLazer();
// change the type of the bolt_type of player
            _player.setBolt_type(bolt_type);
        }
    }
}