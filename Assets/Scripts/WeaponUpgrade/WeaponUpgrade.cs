using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    private Transform gunBarrelEnd;
    private GameObject player;
    public int levelDiagonalWeapon; // maks 9x upgrade
    public int levelFasterWeapon;

    // max level atur disini dah
    private const int maxLevelDiagonal = 9;
    private const int maxLevelSpeed = 2;

    PlayerShooting[] playerShootings;

    private void Awake()
    {
        levelDiagonalWeapon = 0;
        levelFasterWeapon = 0;

        gunBarrelEnd = transform.Find("GunBarrelEnd");
        player = GameObject.FindGameObjectWithTag("Player");

        //for (int i = 0; i < 3; i++)
        //{
        //    UpgradeDiagonalWeapon();
        //}
    }

    public void UpgradeDiagonalWeapon()
    {
        levelDiagonalWeapon++;

        var rotationY = player.transform.eulerAngles.y;
        var right = Quaternion.Euler(0, 10 * levelDiagonalWeapon + rotationY, 0);
        var left = Quaternion.Euler(0, -10 * levelDiagonalWeapon + rotationY, 0);

        Instantiate(gunBarrelEnd, gunBarrelEnd.position, right, player.transform);
        Instantiate(gunBarrelEnd, gunBarrelEnd.position, left, player.transform);

        if (levelDiagonalWeapon >= maxLevelDiagonal)
        {
            WeaponUpgradeManager.isMaxUpgradeDiagonal = true;
        }
    }

    public void UpgradeFasterWeapon()
    {
        levelFasterWeapon++;

        // akses semua gunBarrelEnd
        playerShootings = GetComponentsInChildren<PlayerShooting>();
        Debug.Log("Jumlah player shooting: " + playerShootings.Length);
        foreach (PlayerShooting p in playerShootings)
        {   
            p.timeBetweenBullets -= 0.145f;
        }

        if (levelFasterWeapon >= maxLevelSpeed)
        {
            WeaponUpgradeManager.isMaxUpgradeFaster = true;
        }
    }

    public void UpgradeRearWeapon()
    {
        var rotationY = player.transform.eulerAngles.y;
        var backward = Quaternion.Euler(0, rotationY + 180, 0);
        Instantiate(gunBarrelEnd, gunBarrelEnd.position, backward, player.transform);
    }
}
