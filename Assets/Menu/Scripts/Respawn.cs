using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public GameObject player;
    public Vector3 playerPosition;
    private GameController _gameController;

    public GameObject death;

    public void ReSpawn()
    {
        GameObject gameControllerObject =
            GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            _gameController =
                gameControllerObject.GetComponent<GameController>();
        }


        Instantiate(player, playerPosition, Quaternion.identity);
        // gameObject.SetActive(false);
//        _gameController.death.SetActive(false);
        _gameController.respawn.gameObject.SetActive(false);
        _gameController.backToMenu.gameObject.SetActive(false);
        // death.gameObject.SetActive(false);

        Destroy(death);

        for (int i = 0; i < 5; i++)
        {
            _gameController.IncreaseHP();
        }
    }
}