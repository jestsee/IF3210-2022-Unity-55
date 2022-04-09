using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    [SerializeField] float skeletonRange = 13f;
    [SerializeField] float skeletonRotationSpeed = 5f;

    private Transform playerTransform;
    private SkeletonAttack currentAttack;
    private float fireRate;
    private float fireRateDelta;
    PlayerHealth playerHealth;
    GameObject player;
    EnemyHealth enemyHealth;
    bool isDead;
    Animator anim;
    bool playerInRange;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        currentAttack = GetComponentInChildren<SkeletonAttack>();
        fireRate = currentAttack.GetRateOfFire();
        player = GameObject.FindGameObjectWithTag("Player");
        playerHealth = player.GetComponent<PlayerHealth>();
        enemyHealth = GetComponent<EnemyHealth>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isDead)
        {
            Vector3 playerGroundpos = new Vector3(playerTransform.position.x, transform.position.y, playerTransform.position.z);

            if (Vector3.Distance(transform.position, playerGroundpos) > skeletonRange)
            {
                anim.SetBool("PlayerInRange", false);
            }
            else
            {
                Vector3 playerDirection = playerGroundpos - transform.position;
                float skeletonRotationStep = skeletonRotationSpeed * Time.deltaTime;
                Vector3 newLookDirection = Vector3.RotateTowards(transform.forward, playerDirection, skeletonRotationStep, 0f);
                transform.rotation = Quaternion.LookRotation(newLookDirection);
                fireRateDelta -= Time.deltaTime;

                if (fireRateDelta <= 0 && playerHealth.currentHealth > 0 && enemyHealth.currentHealth > 0)
                {
                    currentAttack.Fire();
                    anim.SetBool("PlayerInRange", true);
                    fireRateDelta = fireRate;
                }
            }
            
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, skeletonRange);
    }
}
