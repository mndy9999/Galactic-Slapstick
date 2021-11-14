using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager mInstance;
    public static GameManager Instance
    {
        get
        {
            if(mInstance == null)
                mInstance = FindObjectOfType<GameManager>();
            return mInstance;
        }
    }

    public GameObject endGameScreen;

    public delegate void UITimerUpdated(string timer, int seconds);
    public static event UITimerUpdated UITimerUpdate;

    public bool GameOver;

    public Gameplay_Manager gameplayScript;

    public void EndGame()
    {
        AudioManager.Instance.PlayGameOver();
        ProjectilesManager.Instance.StopProjectiles();
        GameOver = true;
        if (UITimerUpdate != null)
            UITimerUpdate.Invoke("stop", 0);
        StartCoroutine("ShowEndgameScreen");
    }

    IEnumerator ShowEndgameScreen()
    {
        yield return new WaitForSeconds(2.0f);
        endGameScreen.SetActive(true);
    }


    public void MakeProgress()
    {
        AudioManager.Instance.PlaySwapSound();
        gameplayScript.Timer();
        if (UITimerUpdate != null)
            UITimerUpdate.Invoke("", 10);
    }


}
