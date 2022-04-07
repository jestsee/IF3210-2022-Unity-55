using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeUI : MonoBehaviour
{
    private Transform weaponUpgradeTemplate;
    private Transform container;
    public static bool GameIsPaused = false;

    // private float durationInput = 3f;
    // private float duration;

    private void Awake()
    {
        container = transform.Find("Container");
        weaponUpgradeTemplate = container.Find("WeaponUpgradeTemplate");
        // weaponUpgradeTemplate.gameObject.SetActive(false);
    }

    private void Hide()
    {
        weaponUpgradeTemplate.gameObject.SetActive(false);
    }

    private void Show()
    {
        weaponUpgradeTemplate.gameObject.SetActive(true);
        // duration = durationInput;
    }

    public void Pause()
    {
        Show();

        // freeze the game
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Continue()
    {
        Hide();
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
