using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerSpeed : MonoBehaviour
{
    public float startingSpeed = 10f;
    public float currentSpeed;
    Animator anim;
    public Slider speedSlider;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        currentSpeed = startingSpeed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakePowerUp(int amount)
    {
        currentSpeed += amount;
        speedSlider.value = currentSpeed;
    }
}
