using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerSpeed : MonoBehaviour
{
    public int startingSpeed = 100;
    public int currentSpeed;
    Animator anim;
    public Slider healthSlider;
    public Image damageImage;
    public AudioClip deathClip;
    AudioSource playerAudio;
    PlayerMovement playerMovement;
    PlayerShooting playerShooting;
    PlayerHealth playerHealth;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        playerAudio = GetComponent<AudioSource>();
        playerMovement = GetComponent<PlayerMovement>();
        playerHealth = GetComponent<PlayerHealth>(); //
        playerShooting = GetComponentInChildren<PlayerShooting>();
        currentSpeed = startingSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
