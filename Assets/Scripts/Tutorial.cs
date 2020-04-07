using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    public GameObject laserTutorial;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            laserTutorial.SetActive(true);
            Wait();
        }
    } 

    public void Wait()
    {
        StartCoroutine(WaitingReal());
    }

    IEnumerator WaitingReal()
    {
        yield return new WaitForSecondsRealtime(5);
        laserTutorial.SetActive(false);
    }
}
