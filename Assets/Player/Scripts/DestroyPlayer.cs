using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class DestroyPlayer : MonoBehaviour
{
    public GameObject explosion;
    private GameController _gameController;
    private PlayerInputControl _player;

    public float shakeMagnitude = 2f;

    public GameObject death;
    public Vector3 deathPosition;

    public GameObject backToMenu;

    private void Start()
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

        GameObject playerObject =
            GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            _player =
                playerObject.GetComponent<PlayerInputControl>();
        }

        if (_player == null)
        {
            Debug.Log("Cannot find 'GameController' script");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary")
            || other.gameObject.CompareTag("PlayerShot")
            || other.gameObject.CompareTag("coins")
            || other.gameObject.CompareTag("bonus")
        )
        {
            return;
        }

        Shake();
        if (_gameController.getHP() <= 1 && !_player.protecter.activeSelf)
        {
            _gameController.DecreaseHP();
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            _player.destroyLazer();
            Instantiate(death, deathPosition, Quaternion.identity);
            _gameController.backToMenu.SetActive(true);
            _gameController.respawn.SetActive(true);
        }
        else
        {
            _player.setShieldCount();
            _player.shield.SetActive(true);
            _gameController.DecreaseHP();
        }
    }

    private void Shake()
    {
        CameraShaker.Instance.ShakeOnce(shakeMagnitude, 4f, .1f, 1f);
    }
}