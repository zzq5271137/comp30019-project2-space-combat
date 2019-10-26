using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemy : MonoBehaviour
{
    public GameObject explosion;

    public int health;

    public Renderer renderer;
    public Material matDefault;
    public Material matWhite;

    public GameObject win;
    public Vector3 winPosition;

    private GameController _gameController;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Boundary")
            || other.gameObject.CompareTag("Enemy")
            || other.gameObject.CompareTag("Boss")
            || other.gameObject.CompareTag("EnemyShot")
            || other.gameObject.CompareTag("Asteroid")
            || other.gameObject.CompareTag("coins")
            || other.gameObject.CompareTag("bonus")
//            || other.gameObject.CompareTag("SmallAsteriod")
//            || other.gameObject.CompareTag("PlayerShot")
        )
        {
            return;
        }

        renderer.material = matWhite;

        if (health == 0)
        {
            Instantiate(explosion, transform.position, transform.rotation);
            Destroy(gameObject);
            if (gameObject.CompareTag("Boss"))
            {
                Instantiate(win, winPosition, Quaternion.identity);

                GameObject gameControllerObject =
                    GameObject.FindGameObjectWithTag("GameController");
                if (gameControllerObject != null)
                {
                    _gameController =
                        gameControllerObject.GetComponent<GameController>();
                }

                _gameController.backToMenu.gameObject.SetActive(true);
            }
        }
        else
        {
            health--;
            Invoke("ResetMaterial", .1f);
            if (gameObject.CompareTag("Boss"))
                UpdateBossHealthBar(health);
        }
    }

    private void ResetMaterial()
    {
        renderer.material = matDefault;
    }

    private void UpdateBossHealthBar(int health)
    {
        GameObject gameControllerObject =
            GameObject.FindGameObjectWithTag("GameController");
        if (gameControllerObject != null)
        {
            _gameController =
                gameControllerObject.GetComponent<GameController>();
        }

        _gameController.bossHealthBar.value = (float) health / 200;
    }
}