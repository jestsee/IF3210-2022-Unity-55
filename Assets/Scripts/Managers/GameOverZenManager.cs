using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//using TimerManager;

public class GameOverZenManager : MonoBehaviour
{
    public Text warningText;
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

            if (!isUpdated)
            {
                GameObject waveScoreboard = GameObject.FindGameObjectWithTag("ScoreboardZen");
                ZenScoreboard _waveScoreboard = waveScoreboard.GetComponent<ZenScoreboard>();
                if (_waveScoreboard == null)
                {
                    Debug.Log("Null weh waveScoreboard-nya");
                }
                _waveScoreboard.AddScoreEntry(time, name);
                isUpdated = true;
            }


            anim.SetTrigger("GameOver");
        }
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(2);
        WinManager.isWin = false;
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
        WinManager.isWin = false;
    }
}