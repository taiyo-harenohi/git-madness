using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndOfLevel : MonoBehaviour
{
    public GameObject popUpBox;
    public string sceneName;
    private bool both;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            both = true;
        }
        if (other.gameObject.tag == "Player2" && both)
        {
            PopUp();
        }
    }

    public void PopUp()
    {
        Time.timeScale = 0;
        popUpBox.SetActive(true);
    }

    public void NextSentence()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("mainmenu");
    }
}
