using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveScoreboard : MonoBehaviour
{
    private Transform entryContainer;
    private Transform entryTemplate;
    private List<Transform> scoreEntryTransformList;

    private void Awake()
    {
        Debug.Log("WaveScoreboard awake called");
        entryContainer = transform.Find("ScoreEntryContainer");
        entryTemplate = entryContainer.Find("ScoreEntryTemplate");

        entryTemplate.gameObject.SetActive(false);

        // test add new entry
        // AddScoreEntry(10000, 14, "Haha");

        string jsonString = PlayerPrefs.GetString("scoreTable");
        Scores scores = JsonUtility.FromJson<Scores>(jsonString);

        // sort entry list by score
        for (int i = 0; i < scores.scoreEntryList.Count; i++)
        {
            for (int j = i+1; j < scores.scoreEntryList.Count; j++)
            {
                if (scores.scoreEntryList[j].score > scores.scoreEntryList[i].score)
                {
                    // swap
                    ScoreEntry temp = scores.scoreEntryList[i];
                    scores.scoreEntryList[i] = scores.scoreEntryList[j];
                    scores.scoreEntryList[j] = temp;
                }
            }
        }

        scoreEntryTransformList = new List<Transform>();
        foreach (ScoreEntry scoreEntry in scores.scoreEntryList)
        {
            CreateScoreEntryTransform(scoreEntry, entryContainer, scoreEntryTransformList);
        }

        // Debug.Log(PlayerPrefs.GetString("scoreTable"));
    }

    private void CreateScoreEntryTransform(ScoreEntry scoreEntry, Transform container, List<Transform> transformList)
    {
        float templateHeight = 30f;
        Transform entryTransform = Instantiate(entryTemplate, container);
        RectTransform entryRectTransform = entryTransform.GetComponent<RectTransform>();
        entryRectTransform.anchoredPosition = new Vector2(0, -templateHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rankString;
        switch (rank)
        {
            default:
                rankString = rank + "TH"; break;

            case 1: rankString = "1ST"; break;
            case 2: rankString = "2ND"; break;
            case 3: rankString = "3RD"; break;

        }

        entryTransform.Find("Rank").GetComponent<Text>().text = rankString;

        string name = scoreEntry.name;
        entryTransform.Find("Name").GetComponent<Text>().text = name;

        int wave = scoreEntry.wave;
        entryTransform.Find("Wave").GetComponent<Text>().text = wave.ToString();

        int score = scoreEntry.score;
        entryTransform.Find("Score").GetComponent<Text>().text = score.ToString();

        // set visible odds
        entryTransform.Find("Background").gameObject.SetActive(rank % 2 == 1);

        if (rank == 1)
        {
            Color colorFirst = Color.green;

            // highlight first
            entryTransform.Find("Rank").GetComponent<Text>().color = colorFirst;
            entryTransform.Find("Name").GetComponent<Text>().color = colorFirst;
            entryTransform.Find("Wave").GetComponent<Text>().color = colorFirst;
            entryTransform.Find("Score").GetComponent<Text>().color = colorFirst;

        }

        // set star
        switch (rank)
        {
            default:
                entryTransform.Find("Star").gameObject.SetActive(false);
                break;

            case 1:
                entryTransform.Find("Star").GetComponent<Image>().color = new Color32(255, 221, 0, 255);
                break;

            case 2:
                entryTransform.Find("Star").GetComponent<Image>().color = Color.white;
                break;

            case 3:
                entryTransform.Find("Star").GetComponent<Image>().color = new Color32(224, 151, 99, 255);
                break;
        }

        transformList.Add(entryTransform);
    }

    private void AddScoreEntry(int score, int wave, string name)
    {
        // create scoreEntry
        ScoreEntry scoreEntry = new ScoreEntry { name = name, score = score, wave = wave };

        // load saved scores
        string jsonString = PlayerPrefs.GetString("scoreTable");
        Scores scores = JsonUtility.FromJson<Scores>(jsonString);
        
        // add new entry to scores
        scores.scoreEntryList.Add(scoreEntry);
        
        // ssave updated scores
        string json = JsonUtility.ToJson(scores);
        PlayerPrefs.SetString("scoreTable", json);
        PlayerPrefs.Save();
    }

    private class Scores
    {
        public List<ScoreEntry> scoreEntryList;

    }

    // Represents a single score entry
    [System.Serializable]
    private class ScoreEntry
    {
        public int score;
        public int wave;
        public string name;

    }
}
