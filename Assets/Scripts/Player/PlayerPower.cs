using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerPower : MonoBehaviour
{
    public int startingPower = 20;
    public int currentPower;
    int maxPower = 100;
    Animator anim;
    public Slider powerSlider;

    // Start is called before the first frame update
    void Awake()
    {
        anim = GetComponent<Animator>();
        currentPower = startingPower;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakePowerUp(int amount)
    {
        if (currentPower + amount > maxPower)
        {
            currentPower = maxPower;
        }
        else
        {
            currentPower += amount;
        }
        powerSlider.value = currentPower;
    }
}
