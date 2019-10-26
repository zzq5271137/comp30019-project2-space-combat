using System;
using System.Collections;
using UnityEngine.UI;
using UnityEngine;
using Random = UnityEngine.Random;

public class GameController : MonoBehaviour
{
    public Vector3 spawnValues = new Vector3(6.9f, 10f, 10.55f);

    public GameObject[] asteroids;
    public float asteroidStartWait = 1;
    public int asteroidCount = 3;
    public float asteroidSpawnWait = 3;
    public float asteroidWaveWait = 3;

    public GameObject enemy1;
    public float enemy1StartWait = 2;
    public int enemy1Count = 3;
    public float enemy1SpawnWait = 5;
    public float enemy1WaveWait = 5;

    public GameObject enemy2;
    public float enemy2StartWait = 4;
    public int enemy2Count = 2;
    public float enemy2SpawnWait = 17;
    public float enemy2WaveWait = 17;

    public GameObject enemy3;
    public float enemy3StartWait = 4;
    public int enemy3Count = 2;
    public float enemy3SpawnWait = 17;
    public float enemy3WaveWait = 17;

    public GameObject boss;
    public Vector3 bossSpawnValue;

    public int bossCome = 30;
    private int enemyCount = 0;
    private bool bossHasCame = false;

    public GameObject danger;
    public Vector3 dangerSpawnValue;
    public float waitForBoss;

    public GameObject[] upgrade;
    public GameObject coins;
    public int coinCount;
    public int bonusCount;
    public float bonusSpawnWait;
    public float bonusStartWait;
    public float bonusWaveWait;

    // screen text control
    public Text coinsText;
    public Text hpText;

    private int _coins;
    public int _healthPoint;
    private Boolean lock_healthPoint = false;
    private Boolean powerMode = false;

    public GameObject backToMenu;
    public GameObject respawn;

    public Slider bossHealthBar;

    private bool vulnerable = true;

//    public GameObject death;

    void Start()
    {
        _coins = StatusOfGame.coins;
        UpdateCoins();
        UpdateHP();

        StartCoroutine(SpawnAsteroidWaves());
        StartCoroutine(SpawnEnemy1Waves());
        StartCoroutine(SpawnEnemy2Waves());
        StartCoroutine(SpawnEnemy3Waves());
        StartCoroutine(SpawnBonusWaves());
    }

    void Update()
    {
        if (!bossHasCame && enemyCount > bossCome)
        {
            StartCoroutine(SpawnBoss());
        }

        if (bossHealthBar.value == 0)
            bossHealthBar.gameObject.SetActive(false);
    }

    IEnumerator SpawnBonusWaves()
    {
        // yield return new WaitForSeconds(startWait);
        while (true)
        {
            if (_coins >= 0) // 默认不会单独掉落coins
            {
                // bonus samples
                GameObject hazard = upgrade[Random.Range(0, upgrade.Length)];
                Vector3 spawnPosition = new Vector3(
                    Random.Range(-spawnValues.x, spawnValues.x), spawnValues.y,
                    spawnValues.z);
                Instantiate(hazard, spawnPosition,
                    hazard.transform.localRotation);
                yield return new WaitForSeconds(bonusSpawnWait);
            }
            else
            {
                // coins
                for (int i = 0; i < coinCount; i++)
                {
                    GameObject hazard = coins;
                    Vector3 spawnPosition = new Vector3(
                        Random.Range(-spawnValues.x, spawnValues.x),
                        spawnValues.y, spawnValues.z);
                    Quaternion spawnRotation = Quaternion.identity;
                    Instantiate(hazard, spawnPosition, spawnRotation);
                    yield return new WaitForSeconds(bonusSpawnWait);
                }
            }

            yield return new WaitForSeconds(bonusWaveWait);
        }
    }

    IEnumerator SpawnBoss()
    {
        bossHasCame = true;
        Instantiate(danger, dangerSpawnValue, Quaternion.identity);
        yield return new WaitForSeconds(waitForBoss);
        Instantiate(boss, bossSpawnValue, Quaternion.identity);
        bossHealthBar.gameObject.SetActive(true);
    }

    IEnumerator SpawnAsteroidWaves()
    {
        yield return new WaitForSeconds(asteroidStartWait);
        while (true)
        {
            for (int i = 0; i < asteroidCount; i++)
            {
                GameObject asteroid =
                    asteroids[Random.Range(0, asteroids.Length)];
                SpawnAsteroid(asteroid);
                yield return new WaitForSeconds(Random.Range(0,
                    asteroidSpawnWait));
            }

            yield return new WaitForSeconds(asteroidWaveWait);
        }
    }

    void SpawnAsteroid(GameObject asteroid)
    {
        Vector3 spawnPosition =
            new Vector3(
                Random.Range(-spawnValues.x, spawnValues.x),
                spawnValues.y, spawnValues.z);
        Quaternion spawnRotation = Quaternion.identity;
        Instantiate(asteroid, spawnPosition, spawnRotation);
    }

    IEnumerator SpawnEnemy1Waves()
    {
        yield return new WaitForSeconds(enemy1StartWait);
        while (true)
        {
            for (int i = 0; i < enemy1Count; i++)
            {
                SpawnEnemy(enemy1);
                yield return new WaitForSeconds(Random.Range(0,
                    enemy1SpawnWait));
            }

            yield return new WaitForSeconds(enemy1WaveWait);
        }
    }

    IEnumerator SpawnEnemy2Waves()
    {
        yield return new WaitForSeconds(enemy2StartWait);
        while (true)
        {
            for (int i = 0; i < enemy2Count; i++)
            {
                SpawnEnemy(enemy2);
                yield return new WaitForSeconds(Random.Range(0,
                    enemy2SpawnWait));
            }

            yield return new WaitForSeconds(enemy2WaveWait);
        }
    }

    IEnumerator SpawnEnemy3Waves()
    {
        yield return new WaitForSeconds(enemy3StartWait);
        while (true)
        {
            for (int i = 0; i < enemy3Count; i++)
            {
                SpawnEnemy(enemy3);
                yield return new WaitForSeconds(Random.Range(0,
                    enemy3SpawnWait));
            }

            yield return new WaitForSeconds(enemy3WaveWait);
        }
    }

    void SpawnEnemy(GameObject enemy)
    {
        if (!bossHasCame)
        {
            Vector3 spawnPosition =
                new Vector3(
                    Random.Range(-spawnValues.x, spawnValues.x),
                    spawnValues.y, spawnValues.z);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(enemy, spawnPosition, spawnRotation);
            enemyCount++;
        }
    }

    public void AddCoins()
    {
        _coins += 1;
        StatusOfGame.AddCoin();
        UpdateCoins();
    }

    void UpdateCoins()
    {
        coinsText.text = "Coins: " + _coins;
    }

    // used by enemy
    public void DecreaseHP()
    {
        if (!lock_healthPoint && !powerMode && vulnerable)
        {
            _healthPoint -= 1;
            UpdateHP();
            vulnerable = false;
        }

        StartCoroutine(WaitALittle());
    }

    private IEnumerator WaitALittle()
    {
        yield return new WaitForSecondsRealtime(0.1f);
        vulnerable = true;
    }

    public void IncreaseHP()
    {
        _healthPoint += 1;
        UpdateHP();
    }

    // used by enemy
    void UpdateHP()
    {
        if (_healthPoint < 0)
        {
            _healthPoint = 0;
        }

        hpText.text = "Health Point: " + _healthPoint;
    }

    // used by Shop
    public int getCoins()
    {
        return this._coins;
    }

    public int getHP()
    {
        return this._healthPoint;
    }

    public void unLock_HP()
    {
        this.lock_healthPoint = false;
    }

    public void lock_HP()
    {
        this.lock_healthPoint = true;
    }

    public Boolean getPowerMode()
    {
        return this.powerMode;
    }
}