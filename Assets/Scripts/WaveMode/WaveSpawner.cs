using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{
    public enum SpawnState { SPAWNING, WAITING, COUNTING };

    [System.Serializable]
    public class Wave
    {
        public string name;
        public Transform[] enemyPool;
        public int weight;
        public float rate;
    }

    // array of boss
    public Transform[] bossPool;

    // array of waves
    public Wave[] waves;

    // index of wave
    private int nextWave = 0;

    // random spawn point
    public Transform[] spawnPoints;

    // weapon upgrade
    public WeaponUpgradeUI weaponUpgrade;

    public float timeBetweenWaves = 5f;
    private float waveCountdown;
    private float searchCountdown = 1f;

    private SpawnState state = SpawnState.COUNTING;

    private void Start()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points referenced.");
        }

        waveCountdown = timeBetweenWaves;

        // initialize Waves[]
    }

    private void Update()
    {
        if (state == SpawnState.WAITING)
        {
            // check if enemies are still alive
            if (!EnemyIsAlive())
            {
                // begin a new round
                WaveCompleted();

            } else
            {
                return;
            }
        }

        if (waveCountdown <= 0)
        {
            if (state != SpawnState.SPAWNING)
            {
                // start spawning wave
                StartCoroutine(SpawnWave(waves[nextWave]));
            } 
        }
        else
        {
            waveCountdown -= Time.deltaTime;
        }
    }

    void WaveCompleted ()
    {
        Debug.Log("Wave Completed!");

        // kalo wave yang barusan completed merupakan kelipatan 3
        if ((nextWave+1) % 3 == 0 && nextWave != 0)
        {
            WeaponUpgradeOption();
        }

        state = SpawnState.COUNTING;
        waveCountdown = timeBetweenWaves;

        if (nextWave + 1 > waves.Length - 1)
        {
            // nextWave = -1; // biar pas di-increment jadi 0
            // stuck di wave 6, belom ada tamat
            Debug.Log("All Waves Completed!");
            WinManager.isWin = true;
            return;
        }

        // TODO kondisi wave completed
        if (!WinManager.isWin)
        {
            // klo belom menang lanjut next wave
            // Debug.Log("Belom menang");
            nextWave++;
        }
    }

    bool EnemyIsAlive() // masih belom bener
    {
        searchCountdown -= Time.deltaTime;
        if (searchCountdown <= 0f)
        {
            searchCountdown = 1f;
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0) // dah ga ada musuh
            {
                return false;
            }

        }
        return true;
    }

    IEnumerator SpawnWave (Wave _wave)
    {
        // kalo udah menang
        if (WinManager.isWin)
        {
            yield break;
        }

        Debug.Log("Spawning Wave: " + _wave.name);
        state = SpawnState.SPAWNING;

        // increment wave UI
        WaveManager.wave++;

        // nemy pool kosong
        if (_wave.enemyPool.Length == 0)
        {
            Debug.LogError("Enemy pool is empty!");
        }

        // spawn
        for (int i=0; i<_wave.weight; i++)
        {
            SpawnEnemy(RandomizeEnemy(_wave));
            yield return new WaitForSeconds(1f / _wave.rate);
        }

        // wave dengan nomor kelipatan 3
        if ((nextWave + 1) % 3 == 0)
        {
            Debug.Log("SPAWN BOSS WAVE " + (nextWave + 1));
            // TODO Spawn boss
            //SpawnEnemy(_wave.enemyPool[0]);
            SpawnBoss(bossPool, nextWave);
        }

        // balik set jadi waiting
        state = SpawnState.WAITING;

        yield break;
    }

    void SpawnEnemy (Transform _enemy)
    {
        // spawn enemy
        Debug.Log("Spawning Enemy: " + _enemy.name);

        // TODO setiap enemy ada spawn point masing2?
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
    }

    Transform RandomizeEnemy (Wave _wave)
    {
        return _wave.enemyPool[Random.Range(0, _wave.enemyPool.Length)];
    }

    void SpawnBoss (Transform[] _bossPool, int wave)
    {
        int idx = ((wave + 1) / 3) - 1;

        Transform _boss = _bossPool[idx];

        Debug.Log("Spawning Boss: " + _boss.name);

        // spawn point nya random
        // atau tentuin point khusus boss?
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];

        // spawn boss sesuai dengan wave ke berapa
        Instantiate(_boss, _sp.position, _sp.rotation);
    }

    void WeaponUpgradeOption()
    {
        Debug.Log("Tampilin screen upgrade weapon disini");
        weaponUpgrade.Display();

    }
}
