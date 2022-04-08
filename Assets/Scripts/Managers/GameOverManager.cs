using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text warningText;
    public PlayerHealth playerHealth;
    private Transform gameOverText;    
    private bool isUpdated = false;

    // public float restartDelay = 5f;
    // public WaveScoreboard waveScoreboard;

    Animator anim;
    // float restartTimer;

    void Awake()
    {
        Debug.Log("GameOverManager Awake is called");
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        gameOverText = transform.Find("GameOverText");

        if (playerHealth.currentHealth <= 0 || WinManager.isWin)
        {
            // set win text
            if (WinManager.isWin)
            {
                gameOverText.GetComponent<Text>().text = "You Win!";
            }

            // get name, wave, score
            string name = PlayerPrefs.GetString("name");
            int wave = WaveManager.wave;
            int score = ScoreManager.score;

            // save score to scoreboard
            //if (!isUpdated)
            //{
                //GameObject waveScoreboard = GameObject.FindGameObjectWithTag("ScoreboardWave");
                //WaveScoreboard _waveScoreboard = waveScoreboard.GetComponent<WaveScoreboard>();
                //if (_waveScoreboard == null)
                //{
                //    Debug.Log("Null weh waveScoreboard-nya");
                //}
                //_waveScoreboard.AddScoreEntry(score, wave, name);
                //isUpdated = true;
            //}

            // display game over animation
            anim.SetTrigger("GameOver");

            //restartTimer += Time.deltaTime;

            //if (restartTimer >= restartDelay)
            //{
            //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //}
        }
    }

    public void ShowWarning(float enemyDistance)
    {
        if (playerHealth.currentHealth > 0)
        {
            warningText.text = string.Format("! {0} m", Mathf.RoundToInt(enemyDistance));
            anim.SetTrigger("Warning");

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