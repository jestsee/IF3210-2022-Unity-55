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
        container = transform.Find("WeaponUpgradeContainer");
    }

    public void Pause()
    {
        container.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void SkipOrContinue()
    {
        container.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
