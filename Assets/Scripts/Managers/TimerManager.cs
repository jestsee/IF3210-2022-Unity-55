using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerManager : MonoBehaviour
{
    private float timeDuration = 60f;

    public static float timer;

    public PlayerHealth playerHealth;

    [SerializeField]
    private TextMeshProUGUI firstMinute;
    [SerializeField]
    private TextMeshProUGUI secondMinute;
    [SerializeField]
    private TextMeshProUGUI separator;
    [SerializeField]
    private TextMeshProUGUI firstSecond;
    [SerializeField]
    private TextMeshProUGUI secondSecond;

    // weapon upgrade
    public WeaponUpgradeUI weaponUpgrade;
    private bool callWeaponUpgrade;
    private float counter;

    // Start is called before the first frame update
    void Start()
    {
        callWeaponUpgrade = true;
        timer = 0;
        counter = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth.currentHealth > 0)
        {
            timer += Time.deltaTime;
            UpdateTimerDisplay(timer);
        }

        if (((int)timer)%60 <= 0 && timer>=1 && callWeaponUpgrade)
        {
            WeaponUpgradeOption();
            callWeaponUpgrade = false;
            counter = 0f; // reset
        }

        if (counter >= 5f)
        {
            callWeaponUpgrade = true;
        }

        counter += Time.deltaTime;
    }

    private void UpdateTimerDisplay(float time)
    {
        if (time < 0)
        {
            time = 0;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();
    }

    private void SetTextDisplay(bool enabled)
    {
        firstMinute.enabled = enabled;
        secondMinute.enabled = enabled;
        separator.enabled = enabled;
        firstSecond.enabled = enabled;
        secondSecond.enabled = enabled;
    }

    void WeaponUpgradeOption()
    {
        Debug.Log("Tampilin screen upgrade weapon disini");
        weaponUpgrade.Pause();

    }
}
