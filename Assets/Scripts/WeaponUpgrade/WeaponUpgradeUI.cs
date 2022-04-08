using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponUpgradeUI : MonoBehaviour
{
    private Button upgradeDiagonalButton;
    private Button upgradeFasterButton;
    private Transform container;
    public static bool GameIsPaused = false;

    // private float durationInput = 3f;
    // private float duration;

    private void Awake()
    {
        container = transform.Find("WeaponUpgradeContainer");
        var canvas = container.Find("Canvas");
        var opt = canvas.Find("WeaponUpgradeOptions");
        
        upgradeDiagonalButton = opt.Find("UpgradeDiagonalButton").GetComponent<Button>();
        upgradeFasterButton = opt.Find("UpgradeFasterButton").GetComponent<Button>();
    }

    public void Pause()
    {
        container.gameObject.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void SkipOrContinue()
    {
        if (WeaponUpgradeManager.isMaxUpgradeDiagonal)
        {
            upgradeDiagonalButton.interactable = false;
        }

        if (WeaponUpgradeManager.isMaxUpgradeFaster)
        {
            upgradeFasterButton.interactable = false;
        }

        container.gameObject.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
