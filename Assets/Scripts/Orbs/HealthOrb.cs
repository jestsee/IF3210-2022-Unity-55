using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    public float healthOrbTime = 0.5f;
    public int powerUpValue = 10;
    Animator anim;
    GameObject player;
    PlayerHealth playerHealth;
    float timer;
    bool playerInRange;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (timer >= healthOrbTime)
        //{
        //    // hilang
        // }
        // else {
            if (playerInRange)
            {
                Taken();
                Destroy(this);
            }
        //}
    }

    void OnCollisionEnter(Collision other)
    {
        // Set player in range
        if (other.gameObject == player)
        {
            playerInRange = true;

        }
    }

    // Callback jika ada object yang keluar dari trigger
    void OnCollisionExit(Collision other)
    {
        if (other.gameObject == player)
        {
            playerInRange = false;
        }
    }

    void Taken()
    {
        playerHealth.TakePowerUp(powerUpValue);
    }
}
