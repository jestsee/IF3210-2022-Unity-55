using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float projectileSpeed = 500f;
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;
    public float sinkSpeed = 2.5f;

    private Rigidbody rb;
    Animator anim;
    PlayerHealth playerHealth;
    //EnemyHealth enemyHealth;
    float timer;
    GameObject player;
    
    CapsuleCollider capsuleCollider;
    bool isSinking;
    bool playerInRange;

    private void Start()
    {
        //Mencari game object dengan tag "Player"
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();

        //mendapatkan komponen player health
        playerHealth = player.GetComponent<PlayerHealth>();
        rb = GetComponent<Rigidbody>();
        
        Impulse();
       
    }

    // Update is called once per frame
    private void Impulse()
    {
        rb.AddForce(transform.forward * projectileSpeed, ForceMode.Impulse);
        //transform.Translate(new Vector3(0f, 0f, projectileSpeed * Time.deltaTime));
    }

    void Attack()
    {
        //Reset timer
        timer = 0f;

        //Taking Damage
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
        }
    }

    //Callback jika ada suatu object masuk kedalam trigger
    void OnTriggerEnter(Collider other)
    {
        //Set player in range
        if (other.gameObject == player)
        {
            playerInRange = true;
        }
    }

    //Callback jika ada object yang keluar dari trigger
    void OnTriggerExit(Collider other)
    {
        //Set player not in range
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }


    void Update()
    {
        timer += Time.deltaTime;

        if (/*timer >= timeBetweenAttacks &&*/ playerInRange /*&& enemyHealth.currentHealth > 0*/)
        {
            Attack();
            Destroy(gameObject);
        }
        else
        {
            transform.Translate(-Vector3.up * sinkSpeed * Time.deltaTime);
            Destroy(gameObject,0.8f);
        }
        
        
    }

}


