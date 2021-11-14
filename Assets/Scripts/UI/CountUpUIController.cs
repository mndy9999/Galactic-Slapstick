using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountUpUIController : MonoBehaviour
{

    private TextMeshProUGUI text;
    float timer = 0;
    private bool processing;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        text = GetComponentInChildren<TextMeshProUGUI>();
        GameManager.UITimerUpdate += GameManager_UITimerUpdate;
    }

    private void GameManager_UITimerUpdate(string t, int seconds)
    {
        if (t == "stop")
        {
            processing = true;
            ScoreManager.Instance.SetTime((int)timer);
        }
    }

    void Update()
    {
        if (processing)
            return;

        timer += Time.deltaTime;

        var timespan = TimeSpan.FromSeconds(timer);
        text.text = timespan.ToString(@"mm\:ss");
    }
}
