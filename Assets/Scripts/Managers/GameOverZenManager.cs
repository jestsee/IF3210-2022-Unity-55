using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using TimerManager;

public class GameOverZenManager : MonoBehaviour
{
    
    public PlayerHealth playerHealth;
    private Transform gameOverText;
    private bool isUpdated = false;
    public string time2;

    public float restartDelay = 5f;
    //public WaveScoreboard waveScoreboard;
    public ZenScoreboard waveScoreboard;
    Animator anim;
    float restartTimer;

    void Awake()
    {
        Debug.Log("GameOverManager Awake is called");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        gameOverText = transform.Find("GameOverText");

        if (playerHealth.currentHealth <= 0)
        {
            string name = PlayerPrefs.GetString("name");
            float time = TimerManager.timer;
            Debug.Log(time);
            
            anim.SetTrigger("GameOver");
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(1);
        WinManager.isWin = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        WinManager.isWin = false;
    }
}