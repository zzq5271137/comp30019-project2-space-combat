using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionForCoins : MonoBehaviour
{
    private GameController _gameController;

    void OnTriggerEnter(Collider other)
    {
        // if (other.name.Equals("player"))
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject gameControllerObject =
                GameObject.FindGameObjectWithTag("GameController");
            if (gameControllerObject != null)
            {
                _gameController =
                    gameControllerObject.GetComponent<GameController>();
            }

            if (_gameController == null)
            {
                Debug.Log("Cannot find 'GameController' script");
            }

            Destroy(gameObject);
            _gameController.AddCoins();
        }
    }
}