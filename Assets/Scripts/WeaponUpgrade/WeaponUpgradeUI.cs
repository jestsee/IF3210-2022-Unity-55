using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponUpgradeUI : MonoBehaviour
{
    private Transform weaponUpgradeTemplate;
    private Transform container;
    private float durationInput = 3f;
    private float duration;

    private void Awake()
    {
        container = transform.Find("Container");
        weaponUpgradeTemplate = container.Find("WeaponUpgradeTemplate");
        weaponUpgradeTemplate.gameObject.SetActive(false);
    }

    private void Show()
    {
        weaponUpgradeTemplate.gameObject.SetActive(true);
    }

    private void Hide()
    {
        weaponUpgradeTemplate.gameObject.SetActive(false);
    }

    public void Display()
    {
        Show();
        duration = durationInput;
    }

    private void Update()
    {
        if (duration <= 0)
        {
            Hide();
        }
        else
        {
            duration -= Time.deltaTime;
        }
    }
}
