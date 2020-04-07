using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Attack : MonoBehaviour
{
    public static string nameOfCurrentScene;
    public string nameScene;

    void OnTriggerEnter2D(Collider2D other)
    {
        nameOfCurrentScene = nameScene;
        if (other.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("gameover");
        }
    }
}
