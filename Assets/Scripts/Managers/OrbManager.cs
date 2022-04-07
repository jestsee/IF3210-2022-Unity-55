using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbManager : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public GameObject orb;
    public int spawnOrb;
    public float spawnTime = 15f;

    [SerializeField]
    public MonoBehaviour factory;
    IFactory Factory { get { return factory as IFactory; } }

    void Awake()
    {
        //Mengeksekusi fungs Spawn setiap beberapa detik sesui dengan nilai spawnTime
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }


    void Spawn()
    {
        if (playerHealth.currentHealth <= 0f)
        {
            return;
        }

        //int spawnPointIndex = Random.Range(0, spawnPoints.Length);

        // Menduplikasi enemy
        float x = Random.Range(-34, 34);
        float y = Random.Range(-34, 34);
        Instantiate(Factory.FactoryMethod(spawnOrb), new Vector3(x,0,y), Quaternion.identity);

    }
}
