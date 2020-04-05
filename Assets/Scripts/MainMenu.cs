using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject settingsMenu;
    public GameObject levels;

    public void Play()
    {
        SceneManager.LoadScene("maingame");
    }

    public void Levels()
    {
        mainMenu.SetActive(false);
        levels.SetActive(true);
    }

    public void Settings()
    {
        mainMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        levels.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
