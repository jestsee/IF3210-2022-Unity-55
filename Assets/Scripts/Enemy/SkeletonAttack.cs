using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonAttack : MonoBehaviour
{
    [SerializeField] GameObject projectile;
    [SerializeField] float rateOfFire = 5f;

    
    public float GetRateOfFire()
    {
        return rateOfFire;
    }

    public void Fire()
    {
        Instantiate(projectile, transform.position, transform.rotation);
    }

}
