using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }

    public void Retry()
    {
        SceneManager.LoadScene(Attack.nameOfCurrentScene);
    }
}
