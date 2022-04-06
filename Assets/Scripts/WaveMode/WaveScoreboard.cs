using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveScoreboard : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private void Awake()
    {
        Debug.Log("WaveScoreboard awake called");
        entryContainer = transform.Find("ScoreEntryContainer");
        entryTemplate = entryContainer.Find("ScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        float templateHeight = 30f;
        for (int i=0; i<5; i++)
        {
            Transform entryTransform = Instantiate(entryTemplate, entryContainer);
            RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();

            entryRectTransform.anchoredPosition = new Vector2(0,-templateHeight * i);
            entryTransform.gameObject.SetActive(true);
        }
    }
}
