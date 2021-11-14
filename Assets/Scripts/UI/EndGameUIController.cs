using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameUIController : MonoBehaviour
{
    public void Restart()
    {
        AudioManager.Instance.PlayMainTheme();
        SceneManager.LoadScene(1);
    }

    public void MainMenu()
    {
        AudioManager.Instance.PlayMenuTheme();
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }

}
