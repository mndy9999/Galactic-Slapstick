using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ProgressionCountDownUIController : MonoBehaviour
{

    public float startTime = 10.0f;
    private float currentTime = 10.0f;

    bool processing;

    private TextMeshProUGUI text;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startTime;
        text = transform.GetComponentInChildren<TextMeshProUGUI>();
        GameManager.UITimerUpdate += GameManager_UITimerUpdate;
    }

    private void GameManager_UITimerUpdate(string timer, int seconds)
    {
        if (timer == "stop")
        {
            processing = true;
        }
        else
        {
            processing = false;
            currentTime = seconds;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (processing)
            return;

        if (currentTime <= 0)
        {
            processing = true;
            currentTime = 0;
            GameManager.Instance.MakeProgress();
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
        var timespan = TimeSpan.FromSeconds(currentTime);
        text.text = timespan.ToString(@"ss\:ff");
    }
}
