using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOrb : MonoBehaviour
{
    public float healthOrbTime = 30f;
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
        timer += Time.deltaTime;
        if (timer >= healthOrbTime)
        {
            Destroy(gameObject);
        }
        else {
            if (playerInRange)
            {
                Taken();
                Destroy(gameObject);
            }
        }
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
