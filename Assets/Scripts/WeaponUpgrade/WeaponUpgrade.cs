using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgrade : MonoBehaviour
{
    private Transform gunBarrelEnd;
    private GameObject player;
    private int levelDiagonalWeapon; // maks 9x upgrade
    private int levelFasterWeapon;

    // TODO max level?

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
    }

    public void UpgradeFasterWeapon()
    {
        levelFasterWeapon++;

        // TODO akses semua gunBarrelEnd
    }

    public void UpgradeRearWeapon()
    {
        var rotationY = player.transform.eulerAngles.y;
        var backward = Quaternion.Euler(0, -1 * rotationY, 0);
        Instantiate(gunBarrelEnd, gunBarrelEnd.position, backward, player.transform);

        // TODO masih aneh
    }
}
