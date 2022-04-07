using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    private Transform gunBarrelEnd;
    private GameObject player;

    private void Awake()
    {
        gunBarrelEnd = transform.Find("GunBarrelEnd");
        player = GameObject.FindGameObjectWithTag("Player");

        // Instantiate(gunBarrelEnd, gunBarrelEnd.position, Quaternion.Euler(0, 20, 0), player.transform);
        // Instantiate(gunBarrelEnd, gunBarrelEnd.position, Quaternion.Euler(0, -20, 0), player.transform);

    }
}
