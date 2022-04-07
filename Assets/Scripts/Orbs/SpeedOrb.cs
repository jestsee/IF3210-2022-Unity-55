using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedOrb : MonoBehaviour
{
    public float speedOrbTime = 0.5f;
    public int powerUpValue = 10;
    Animator anim;
    GameObject player;
    PlayerSpeed playerSpeed;
    float timer;
    // Start is called before the first frame update
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerSpeed = player.GetComponent<PlayerSpeed>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (timer >= speedOrbTime)
        {
            // hilang
        }
    }

    void Taken()
    {
        playerSpeed.TakePowerUp(powerUpValue);
    }
}
