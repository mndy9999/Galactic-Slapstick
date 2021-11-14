using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class ScoreManager : MonoBehaviour
{
    private static ScoreManager mInstance;
    public static ScoreManager Instance
    {
        get
        {
            if (mInstance == null)
                mInstance = FindObjectOfType<ScoreManager>();
            return mInstance;
        }
    }

    private List<int> scores;
    public List<TextMeshProUGUI> scoresText;
    public TextMeshProUGUI currentTimeText;

    private void Start()
    {
        var savedData = SaveSystem.LoadScore();
        scores = new List<int>();
        scores.Add(savedData.topSeconds[0]);
        scores.Add(savedData.topSeconds[1]);
        scores.Add(savedData.topSeconds[2]);
        UpdateScores();
    }

    public void SetTime(int time)
    {
        currentTimeText.text = TimeSpan.FromSeconds(time).ToString(@"mm\:ss");
        if (scores.Contains(time))
            return;
        scores.Add(time);
        scores.Sort();
        scores.Reverse();
        scores.RemoveAt(3);
        UpdateScores();
        SaveSystem.SaveScore(scores[0], scores[1], scores[2]);
    }

    private void UpdateScores()
    {
        scoresText[0].text = TimeSpan.FromSeconds(scores[0]).ToString(@"mm\:ss");
        scoresText[1].text = TimeSpan.FromSeconds(scores[1]).ToString(@"mm\:ss");
        scoresText[2].text = TimeSpan.FromSeconds(scores[2]).ToString(@"mm\:ss");
    }

}
