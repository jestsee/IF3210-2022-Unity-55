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
        if (timer >= powerOrbTime)
        {
            // hilang
        }
    }

    void Taken()
    {
        playerPower.TakePowerUp(powerUpValue);
    }
}
