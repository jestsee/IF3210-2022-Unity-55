using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerOrb : MonoBehaviour
{
    public float powerOrbTime = 0.5f;
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
        playerPower = player.GetComponent<PlayerPower>();
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
        playerPower.TakePowerUp(powerUpValue);
    }
}
