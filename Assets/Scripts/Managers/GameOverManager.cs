using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text warningText;
    public PlayerHealth playerHealth;
    public float restartDelay = 5f;
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
        if (playerHealth.currentHealth <= 0)
        {
            // get name, wave, score
            string name = PlayerPrefs.GetString("name");
            int wave = WaveManager.wave;
            int score = ScoreManager.score;
            Debug.Log("SCORE: " + name + " " + wave + " " + score);

            // save score to scoreboard
            // WaveScoreboard.AddScoreEntry(score, wave, name);

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
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}