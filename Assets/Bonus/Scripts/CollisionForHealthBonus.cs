using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionForHealthBonus : MonoBehaviour
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

            if (gameControllerObject == null)
            {
                Debug.Log("Cannot find 'game controller' script");
            }

            if (_gameController.getHP() < 5)
                _gameController.IncreaseHP();
            Destroy(gameObject);
        }
    }
}