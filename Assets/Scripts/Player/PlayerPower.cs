using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPower : MonoBehaviour
{
    public int startingPower = 100;
    public int currentPower;
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
        currentPower = startingPower;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
