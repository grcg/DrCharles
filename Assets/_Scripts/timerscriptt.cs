using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class timerscriptt : MonoBehaviour {

    public float delay = 11;
    public string NewLevelString= "Bootcamp";

    // Use this for initialization
    void Start() {

        StartCoroutine(LoadLevelAfterDelay(delay));

    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene("GamePage 1");
    }

}