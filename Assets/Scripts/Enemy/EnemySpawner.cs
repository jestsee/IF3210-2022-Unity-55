using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject enemy;
    public int spawnEnemy;
    public float spawnTime = 3f;
    public Transform[] spawnPoints;

    ObjectPooler objectPooler;

    [SerializeField]
    public MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Start()
    {
        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        objectPooler = ObjectPooler.Instance;
    }


    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Menduplikasi enemy
        //Instantiate(Factory.FactoryMethod(spawnEnemy), spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
        objectPooler.SpawnFromPool("ZomBear", transform.position, Quaternion.identity);
        objectPooler.SpawnFromPool("ZomBunny", transform.position, Quaternion.identity);
        objectPooler.SpawnFromPool("Hellephant", transform.position, Quaternion.identity);

    }
}
