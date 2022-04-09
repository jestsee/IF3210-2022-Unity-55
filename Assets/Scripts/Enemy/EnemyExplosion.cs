using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyExplosion : MonoBehaviour
{
    Animator anim;
    public GameObject Explosion;
    GameObject player;
    UnityEngine.AI.NavMeshAgent nav;
    bool playerInRange;
    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void OnTriggerEnter(Collider other)
    {
        // Set player in range
        if (other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = true;

        }
    }

    // Callback jika ada object yang keluar dari trigger
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player && other.isTrigger == false)
        {
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //int explode = Random.Range(0, 100);
        if (playerInRange)
        {
            GameObject exploder = Instantiate(Explosion, transform.position, transform.rotation).gameObject;
            Destroy(gameObject, 0.001f);
            Destroy(exploder, 2.0f);
        }
    }

    void DamagePlayer()
    {
    }
}
