using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionForSuper : MonoBehaviour
{
    private GameController _gameController;
    private PlayerInputControl _player;

    void OnTriggerEnter(Collider other)
    {
        // if (other.name.Equals("player"))
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject gameControllerObject =
                GameObject.FindGameObjectWithTag("GameController");
            GameObject playerObject =
                GameObject.FindGameObjectWithTag("Player");
            if (gameControllerObject != null)
            {
                _gameController =
                    gameControllerObject.GetComponent<GameController>();
                _player = playerObject.GetComponent<PlayerInputControl>();
            }

            if (gameControllerObject == null)
            {
                Debug.Log("Cannot find 'game controller' script");
            }

            Debug.Log("!!");
            _player.protecter.gameObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}