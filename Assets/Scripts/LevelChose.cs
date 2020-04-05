using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LevelChose : MonoBehaviour
{
    public void ChoseLevel()
    {
        switch (EventSystem.current.currentSelectedGameObject.name)
        {
            case "Level1":
                SceneManager.LoadScene("maingame");
                break;
            /*case "Chapter 2":
                SceneManager.LoadScene("story2");
                break;
            case "Chapter 3":
                SceneManager.LoadScene("story3");
                break;
            case "Chapter 4":
                SceneManager.LoadScene("story4");
                break;
            case "Chapter 5":
                SceneManager.LoadScene("story5");
                break;*/
            default:
                break;
        }
    }
}
