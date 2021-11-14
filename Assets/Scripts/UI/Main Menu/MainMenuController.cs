using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public GameObject mainPanel;
    public GameObject settingsPanel;
    public GameObject timesPanel;

    public void Play()
    {
        AudioManager.Instance.PlayMainTheme();
        SceneManager.LoadScene(1);
    }

    public void OpenCloseSettings()
    {
        mainPanel.SetActive(!mainPanel.activeSelf);
        settingsPanel.SetActive(!settingsPanel.activeSelf);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenCloseTimes()
    {
        mainPanel.SetActive(!mainPanel.activeSelf);
        timesPanel.SetActive(!timesPanel.activeSelf);
    }

}
