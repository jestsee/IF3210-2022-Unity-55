using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOrb : MonoBehaviour
{
    public float powerOrbTime = 30f;
    public int powerUpValue = 10;
    Animator anim;
    GameObject player;
    PlayerPower playerPower;
    float timer;
    bool playerInRange;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerPower = player.GetComponentInChildren<PlayerPower>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= powerOrbTime)
        {
            Destroy(gameObject);
        }
        else
        {
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
        playerPower.TakePowerUp(powerUpValue);
    }
}
